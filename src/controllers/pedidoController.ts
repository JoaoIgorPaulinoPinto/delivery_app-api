import { Body, Controller, Get, Path, Post, Response, Route, Tags } from "tsoa";
import { PedidoProdutoResponseDTO } from "../dtos/pedido-produto.dto";
import { PedidoCreateDTO, PedidoResponseDTO } from "../dtos/pedido.dto";
import PedidosService from "../services/pedidoService";

@Route("pedidos")
@Tags("Pedidos")
export class PedidoController extends Controller {
  @Get("/")
  public async getPedidos(): Promise<PedidoResponseDTO[]> {
    const pedidos = await PedidosService.listar();
    return pedidos.map((pedido) => ({
      id: pedido.id,
      cliente: pedido.usuario ?? "Desconhecido",
      criadoEm: pedido.feitoEm,
      status: pedido.status,
      usuario: pedido.usuario,
      endereco: pedido.endereco,
      metodoPagamento: pedido.metodoPagamento,
      pedidoProdutos: pedido.produtopedido.map((pp) => ({
        id: pp.id,
        produtoId: pp.idProduto,
        quantidade: pp.quantidade,
        obs: pp.observacao,
        produto: {
          id: pp.produto.id,
          nome: pp.produto.nome,
          preco: pp.produto.preco ? Number(pp.produto.preco) : 0,
          descricao: pp.produto.descricao,
        },
      })),
    }));
  }

  @Get("/{id}")
  @Response<null>(404, "Pedido não encontrado")
  public async getPedidosById(
    @Path() id: number
  ): Promise<PedidoResponseDTO | null> {
    const pedido = await PedidosService.listarPorId(id);

    if (!pedido) {
      this.setStatus(404);
      return null;
    }

    const pedidoDTO: PedidoResponseDTO = {
      criadoEm: pedido.feitoEm,
      status: pedido.status,
      endereco: pedido.endereco,
      metodoPagamento: pedido.metodoPagamento,
      pedidoProdutos: pedido.produtopedido.map((pp) => {
        const newProd: PedidoProdutoResponseDTO = {
          id: pp.id,
          produtoId: pp.idProduto,
          quantidade: pp.quantidade,
          obs: pp.observacao,
          produto: {
            id: pp.produto.id,
            nome: pp.produto.nome,
            preco: pp.produto.preco ? Number(pp.produto.preco) : 0,
            descricao: pp.produto.descricao,
          },
        };
        return newProd;
      }),
    };

    return pedidoDTO;
  }

  @Post("/")
  public async createPedido(
    @Body() data: PedidoCreateDTO
  ): Promise<PedidoResponseDTO> {
    const newPedido: PedidoCreateDTO = {
      metodoPagamento: data.metodoPagamento,
      idEstabelecimento: data.idEstabelecimento,
      endereco: data.endereco,
      usuario: data.usuario,
      pedidoProdutos: data.pedidoProdutos,
    };

    const pedido = await PedidosService.cadastrar(newPedido);

    return {
      criadoEm: pedido.pedido.feitoEm,
      status: pedido.pedido.status,
      endereco: pedido.pedido.endereco,
      metodoPagamento: pedido.pedido.metodoPagamento,
      pedidoProdutos: pedido.pedido.produtopedido.map((pp) => ({
        id: pp.id,
        produtoId: pp.idProduto,
        quantidade: pp.quantidade,
        obs: pp.observacao,
        produto: {
          id: pp.produto.id,
          nome: pp.produto.nome,
          preco: pp.produto.preco ? Number(pp.produto.preco) : 0,
          descricao: pp.produto.descricao,
        },
      })),
    };
  }
}
