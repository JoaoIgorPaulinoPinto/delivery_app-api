import prisma from "../config/prisma";
import { PedidoCreateDTO } from "../dtos/pedido.dto";

const listar = async () => {
  const pedidos = await prisma.pedido.findMany({
    include: {
      produtopedido: {
        include: {
          produto: true, // Inclui os detalhes dos produtos
        },
      },
      estabelecimento: true, // Inclui info do estabelecimento
    },
    orderBy: {
      id: "asc",
    },
  });

  return pedidos;
};

const listarPorId = async (id: number) => {
  const pedido = await prisma.pedido.findUnique({
    where: { id: Number(id) },
    include: {
      produtopedido: {
        include: {
          produto: true,
        },
      },
      estabelecimento: true,
    },
  });

  if (!pedido) throw new Error("Pedido não encontrado");

  return pedido;
};

const cadastrar = async (data: PedidoCreateDTO) => {
  const novoPedido = await prisma.pedido.create({
    data: {
      feitoEm: new Date(),
      status: "PENDENTE",
      usuario: data.usuario,
      endereco: data.endereco,
      metodoPagamento: data.metodoPagamento,
      idEstabelecimento: data.idEstabelecimento,

      produtopedido: {
        create: data.pedidoProdutos.map((p) => ({
          idProduto: p.produtoId,
          quantidade: p.quantidade,
          observacao: p.obs || "",
        })),
      },
    },
    include: {
      produtopedido: {
        include: {
          produto: true,
        },
      },
    },
  });

  return {
    message: "Pedido cadastrado com sucesso!",
    pedido: novoPedido,
  };
};

export default { listar, listarPorId, cadastrar };
