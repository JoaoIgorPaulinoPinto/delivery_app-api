using comaagora.DTO;
using comaagora.Models;
using comaagora.Repositories;

namespace comaagora.Services.Pedido
{
    public class PedidoService : IPedidoService
    {
        private readonly PedidoRepository _repository;

        public PedidoService(PedidoRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> CreatePedido(int estabelecimentoId, CreatePedidoDTO dto)
        {
            // 1️⃣ Validação básica
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "Dados do pedido não podem ser nulos.");

            if (dto.Produtos == null || !dto.Produtos.Any())
                throw new ArgumentException("O pedido deve conter pelo menos um produto.");

            if (string.IsNullOrWhiteSpace(dto.Usuario?.Nome) || string.IsNullOrWhiteSpace(dto.Usuario?.Telefone))
                throw new ArgumentException("Nome e telefone do usuário são obrigatórios.");

            if (dto.Endereco == null 
                || string.IsNullOrWhiteSpace(dto.Endereco.Rua)
                || string.IsNullOrWhiteSpace(dto.Endereco.Bairro)
                || string.IsNullOrWhiteSpace(dto.Endereco.Cidade))
            {
                throw new ArgumentException("Endereço incompleto.");
            }

            // 2️⃣ Verificar se o estabelecimento existe
            var estabelecimento = await _repository.GetEstabelecimentoByIdAsync(estabelecimentoId);
            if (estabelecimento == null)
                throw new KeyNotFoundException("Estabelecimento não encontrado.");

            // 3️⃣ Criar endereço
            var endereco = new Endereco
            {
                CEP =dto.Endereco.CEP,
                UF =dto.Endereco.UF,
                Complemento = dto.Endereco.Complemento,
                EstabelecimentoId = estabelecimentoId,
                Rua = dto.Endereco.Rua,
                Numero = dto.Endereco.Numero,
                Bairro = dto.Endereco.Bairro,
                Cidade = dto.Endereco.Cidade
            };
            await _repository.AddEnderecoAsync(endereco);

            // 4️⃣ Criar usuário
            var usuario = new Usuario
            {
                Nome = dto.Usuario.Nome,
                Telefone = dto.Usuario.Telefone,
                EnderecoId = endereco.Id,
                EstabelecimentoId = estabelecimentoId,
                clientKey = "client key"
                
            };
            await _repository.AddUsuarioAsync(usuario);

            // 5️⃣ Criar pedido
            var pedido = new Models.Pedido
            {
                UsuarioId = usuario.Id,
                EstabelecimentoId = estabelecimentoId,
                MetodoPagamentoId = dto.MetodoPagamentoId,
                EnderecoId = endereco.Id,
                Observacao = dto.Observacao,
            };
            await _repository.AddPedidoAsync(pedido);

            // 6️⃣ Adicionar produtos
            var produtosPedido = new List<ProdutoPedido>();
            foreach (var item in dto.Produtos)
            {
                var produto = await _repository.GetProdutoByIdAsync(item.ProdutoId);
                if (produto == null)
                    throw new KeyNotFoundException($"Produto com ID {item.ProdutoId} não encontrado.");

                if (item.Quantidade <= 0)
                    throw new ArgumentException($"Quantidade do produto {produto.Nome} deve ser maior que zero.");

                produtosPedido.Add(new ProdutoPedido
                {
                    PedidoId = pedido.Id,
                    ProdutoId = item.ProdutoId,
                    Quantidade = item.Quantidade,
                    EstabelecimentoId = estabelecimentoId,
                    
                    Produto = produto,
                    Pedido = pedido,
                });
            }
            await _repository.AddProdutosPedidoAsync(produtosPedido);

            return pedido.Id.ToString();
        }

        public async Task<GetPedidoDTO> GetPedidoById(int id, int estabelecimentoId)
        {
            var pedido = await _repository.GetByIdAsync(id, estabelecimentoId);

            if (pedido == null )
                throw new KeyNotFoundException("Pedido não encontrado.");
            if (pedido.Estabelecimento == null)
                throw new KeyNotFoundException("Estabelecimento não encontrado.");
            if (pedido.Usuario == null)
                throw new KeyNotFoundException("Usuario nao encontrado");
            return new GetPedidoDTO
            {
                Estabelecimento = pedido.Estabelecimento.NomeFantasia,
                produtos = pedido.Produtos.Select(prod => new GetProdutoPedidoDTO
                {
                    Produto = prod.Produto.Nome,
                    Preco = prod.Produto.Preco,
                    Quantidade = prod.Quantidade
                }).ToList(),
                usuario = new GetUsuarioDTO
                {
                    nome = pedido.Usuario.Nome,
                    telefone = pedido.Usuario.Telefone
                }
            };
        }
    }
}
