import { ProdutoResponseDTO } from "./produto.dto";

// pedido-produto.dto.ts
export interface PedidoProdutoCreateDTO {
  produtoId: number;
  quantidade: number;
  obs: string;
}

export interface PedidoProdutoUpdateDTO {
  produtoId?: number;
  quantidade?: number;
  obs?: string;
}

export interface PedidoProdutoResponseDTO {
  id: number;
  produtoId: number;
  quantidade: number;
  obs: string;
  produto?: ProdutoResponseDTO;
}
