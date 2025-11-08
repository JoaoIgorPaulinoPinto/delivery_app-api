"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.getProdutos = void 0;
const produtoService_1 = __importDefault(require("../services/produtoService"));
const getProdutos = async (req, res) => {
    const produtos = await produtoService_1.default.listar();
    res.json(produtos);
};
exports.getProdutos = getProdutos;
