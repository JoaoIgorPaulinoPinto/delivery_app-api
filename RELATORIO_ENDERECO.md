# Relatorio de ajustes - Endereco

Data: 2026-03-03

## Escopo solicitado
- Remover dependencia de FK de endereco nas regras de negocio.
- Buscar endereco separadamente das entidades.
- Considerar `Endereco.Usuario` como dono do endereco.
- Corrigir erros relacionados a endereco e registrar achados adicionais.

## Correcoes aplicadas
1. Busca de endereco separada por dono (`Usuario`)
- `IEnderecoService` agora expõe:
  - `GetByUsuarioIdAsync(int usuarioId)`
  - `GetByUsuariosIdsAsync(IEnumerable<int> usuarioIds)`
- `EnderecoRepository` passou a carregar endereco por dono com `AsNoTracking` e inclui `Cidade`/`Uf`.
- Adicionada busca em lote para reduzir N+1 em listagens.

2. Pedido com endereco desacoplado da entidade
- `PedidoService` foi ajustado para:
  - Criar e persistir endereco separado do `Pedido`.
  - Consultar endereco do pedido via `Endereco.Usuario = pedido.Id`.
  - Consultar endereco do estabelecimento separadamente via `Endereco.Usuario = estabelecimento.Id`.
  - Mapear corretamente os dois enderecos no DTO (antes o endereco do pedido era reutilizado para estabelecimento).

3. Estabelecimento sem dependencia de navegacao de endereco
- `EstabelecimentoRepository.GetBySlug` removeu projecao que dependia de `Estabelecimento.Endereco`.
- `EstabelecimentoService` passou a buscar endereco separadamente via `IEnderecoService`.

4. Modelo de endereco sem colecoes para entidades de negocio
- Removidas navegacoes de negocio em `Models/Endereco.cs` (ex.: colecao de estabelecimentos), evitando acoplamento por relacao de entidade no modelo.

## Erros adicionais encontrados
1. Inconsistencia de snapshot/migrations (preexistente)
- `Migrations/AppDbContextModelSnapshot.cs` ainda descreve relacoes antigas de endereco (ex.: FK com estabelecimento/pedido/usuario), divergindo dos modelos atuais.
- Impacto: futuras migrations podem ser geradas incorretamente se o snapshot nao for normalizado.

2. Ambiguidade de dono de endereco (regra de dominio)
- A coluna `Endereco.Usuario` esta sendo usada como dono para contextos diferentes (pedido e estabelecimento), ambos inteiros.
- Impacto: risco de colisao sem um discriminador de tipo de dono.

3. Validacao de build bloqueada por ambiente
- Nao foi possivel validar compilacao/restaure devido bloqueio de rede para `api.nuget.org` (NU1301).

## Recomendacao tecnica
1. Criar migration de saneamento para remover FKs/colunas legadas de endereco nas tabelas de negocio e atualizar o snapshot.
2. Introduzir discriminador de dono no endereco (ex.: `OwnerType`) para eliminar ambiguidade entre pedido e estabelecimento.
3. Reexecutar `dotnet restore`/`dotnet build` em ambiente com acesso ao NuGet para validacao final.
