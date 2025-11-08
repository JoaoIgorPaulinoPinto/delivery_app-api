"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = require("express");
const produtoController_1 = require("../controllers/produtoController");
const router = (0, express_1.Router)();
router.get("/", produtoController_1.getProdutos);
exports.default = router;
