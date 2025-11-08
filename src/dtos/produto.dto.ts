export interface ProdutoCreateDTO {
  nome: string;
  preco: number;
}

export interface ProdutoUpdateDTO {
  nome?: string;
  preco?: number;
}

export interface ProdutoResponseDTO {
  id: number;
  nome: string;
  preco: number;
  descricao: string;
}
