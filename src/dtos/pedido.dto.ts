import {
  PedidoProdutoCreateDTO,
  PedidoProdutoResponseDTO,
  PedidoProdutoUpdateDTO,
} from "./pedido-produto.dto";

// pedido.dto.ts
export interface PedidoCreateDTO {
  metodoPagamento: string;
  idEstabelecimento: number;
  endereco: string;
  usuario?: string;
  pedidoProdutos: PedidoProdutoCreateDTO[];
}

export interface PedidoUpdateDTO {
  cliente?: string;
  endereco?: string;
  status?: string;
  usuarioId?: number;
  pedidoProdutos?: PedidoProdutoUpdateDTO[];
}

export interface PedidoResponseDTO {
  // id: number;
  // cliente: string;
  endereco: string;
  criadoEm: Date;
  status: string;
  // usuarioId?: number | null;
  metodoPagamento: string;
  // usuario?: string;
  pedidoProdutos: PedidoProdutoResponseDTO[];
}
