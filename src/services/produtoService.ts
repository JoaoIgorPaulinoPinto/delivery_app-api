import prisma from "../config/prisma";
import { ProdutoResponseDTO } from "../dtos/produto.dto";

const Listar = async () => {
  const lista = await prisma.produto.findMany();

  const produtos: ProdutoResponseDTO[] = lista.map((produto) => ({
    id: produto.id,
    nome: produto.nome,
    preco: produto.preco ? Number(produto.preco) : 0,
    descricao: produto.descricao,
  }));
  return produtos;
};

const PegarPorId = async (id: number) => {
  const data = await prisma.produto.findUnique({
    where: { id: id },
  });
  const produto: ProdutoResponseDTO = {
    id: data!.id,
    nome: data!.nome,
    preco: data!.preco ? Number(data!.preco) : 0,
    descricao: data!.descricao,
  };
  return produto;
};

export default { listar: Listar, listarPorId: PegarPorId };
