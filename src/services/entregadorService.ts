import prisma from "../config/prisma";

const listar = async () => {
  return await prisma.entregador.findMany();
};

export default { listar };
