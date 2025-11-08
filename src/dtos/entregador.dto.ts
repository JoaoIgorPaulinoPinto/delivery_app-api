// entregador.dto.ts

export interface EntregadorCreateDTO {
  nome: string;
  cpf: string;
  veiculo?: string;
  idEstabelecimento: number;
}

export interface EntregadorUpdateDTO {
  nome?: string;
  cpf?: string;
  veiculo?: string;
  idEstabelecimento?: number;
}

export interface EntregadorResponseDTO {
  id: number;
  nome: string;
  cpf: string;
  veiculo?: string | null;
  idEstabelecimento: number;
  criadoEm: Date;
}
