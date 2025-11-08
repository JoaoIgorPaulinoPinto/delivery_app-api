import { Controller, Get, Path, Response, Route, Tags } from "tsoa";
import { ProdutoResponseDTO } from "../dtos/produto.dto";
import produtoService from "../services/produtoService";

@Route("produtos")
@Tags("Produtos")
export class ProdutoController extends Controller {
  /** Retorna todos os produtos */
  @Get("/")
  public async getProdutos(): Promise<ProdutoResponseDTO[]> {
    const produtos = await produtoService.listar();
    return produtos;
  }

  /** Retorna um produto específico pelo ID */
  @Get("/{id}")
  @Response<null>(404, "Produto não encontrado")
  public async getProdutoById(
    @Path() id: number
  ): Promise<ProdutoResponseDTO | null> {
    const produto = await produtoService.listarPorId(id);
    if (!produto) {
      this.setStatus(404); // Retorna 404 no Swagger e na resposta real
      return null;
    }
    return produto;
  }
}
