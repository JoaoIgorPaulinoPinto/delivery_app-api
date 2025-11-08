import { Request, Response } from "express";
import userService from "../services/entregadorService";

export const getUsers = async (req: Request, res: Response) => {
  const users = await userService.listar();
  res.json(users);
};
