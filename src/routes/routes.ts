/* tslint:disable */
/* eslint-disable */
// WARNING: This file was auto-generated with tsoa. Please do not modify it. Re-run tsoa to re-generate this file: https://github.com/lukeautry/tsoa
import type { TsoaRoute } from '@tsoa/runtime';
import {  fetchMiddlewares, ExpressTemplateService } from '@tsoa/runtime';
// WARNING: This file was auto-generated with tsoa. Please do not modify it. Re-run tsoa to re-generate this file: https://github.com/lukeautry/tsoa
import { ProdutoController } from './../controllers/produtoController';
// WARNING: This file was auto-generated with tsoa. Please do not modify it. Re-run tsoa to re-generate this file: https://github.com/lukeautry/tsoa
import { PedidoController } from './../controllers/pedidoController';
import type { Request as ExRequest, Response as ExResponse, RequestHandler, Router } from 'express';



// WARNING: This file was auto-generated with tsoa. Please do not modify it. Re-run tsoa to re-generate this file: https://github.com/lukeautry/tsoa

const models: TsoaRoute.Models = {
    "ProdutoResponseDTO": {
        "dataType": "refObject",
        "properties": {
            "id": {"dataType":"double","required":true},
            "nome": {"dataType":"string","required":true},
            "preco": {"dataType":"double","required":true},
            "descricao": {"dataType":"string","required":true},
        },
        "additionalProperties": false,
    },
    // WARNING: This file was auto-generated with tsoa. Please do not modify it. Re-run tsoa to re-generate this file: https://github.com/lukeautry/tsoa
    "PedidoProdutoResponseDTO": {
        "dataType": "refObject",
        "properties": {
            "id": {"dataType":"double","required":true},
            "produtoId": {"dataType":"double","required":true},
            "quantidade": {"dataType":"double","required":true},
            "obs": {"dataType":"string","required":true},
            "produto": {"ref":"ProdutoResponseDTO"},
        },
        "additionalProperties": false,
    },
    // WARNING: This file was auto-generated with tsoa. Please do not modify it. Re-run tsoa to re-generate this file: https://github.com/lukeautry/tsoa
    "PedidoResponseDTO": {
        "dataType": "refObject",
        "properties": {
            "endereco": {"dataType":"string","required":true},
            "criadoEm": {"dataType":"datetime","required":true},
            "status": {"dataType":"string","required":true},
            "metodoPagamento": {"dataType":"string","required":true},
            "pedidoProdutos": {"dataType":"array","array":{"dataType":"refObject","ref":"PedidoProdutoResponseDTO"},"required":true},
        },
        "additionalProperties": false,
    },
    // WARNING: This file was auto-generated with tsoa. Please do not modify it. Re-run tsoa to re-generate this file: https://github.com/lukeautry/tsoa
    "PedidoProdutoCreateDTO": {
        "dataType": "refObject",
        "properties": {
            "produtoId": {"dataType":"double","required":true},
            "quantidade": {"dataType":"double","required":true},
            "obs": {"dataType":"string","required":true},
        },
        "additionalProperties": false,
    },
    // WARNING: This file was auto-generated with tsoa. Please do not modify it. Re-run tsoa to re-generate this file: https://github.com/lukeautry/tsoa
    "PedidoCreateDTO": {
        "dataType": "refObject",
        "properties": {
            "metodoPagamento": {"dataType":"string","required":true},
            "idEstabelecimento": {"dataType":"double","required":true},
            "endereco": {"dataType":"string","required":true},
            "usuario": {"dataType":"string"},
            "pedidoProdutos": {"dataType":"array","array":{"dataType":"refObject","ref":"PedidoProdutoCreateDTO"},"required":true},
        },
        "additionalProperties": false,
    },
    // WARNING: This file was auto-generated with tsoa. Please do not modify it. Re-run tsoa to re-generate this file: https://github.com/lukeautry/tsoa
};
const templateService = new ExpressTemplateService(models, {"noImplicitAdditionalProperties":"throw-on-extras","bodyCoercion":true});

// WARNING: This file was auto-generated with tsoa. Please do not modify it. Re-run tsoa to re-generate this file: https://github.com/lukeautry/tsoa




export function RegisterRoutes(app: Router) {

    // ###########################################################################################################
    //  NOTE: If you do not see routes for all of your controllers in this file, then you might not have informed tsoa of where to look
    //      Please look into the "controllerPathGlobs" config option described in the readme: https://github.com/lukeautry/tsoa
    // ###########################################################################################################


    
        const argsProdutoController_getProdutos: Record<string, TsoaRoute.ParameterSchema> = {
        };
        app.get('/produtos',
            ...(fetchMiddlewares<RequestHandler>(ProdutoController)),
            ...(fetchMiddlewares<RequestHandler>(ProdutoController.prototype.getProdutos)),

            async function ProdutoController_getProdutos(request: ExRequest, response: ExResponse, next: any) {

            // WARNING: This file was auto-generated with tsoa. Please do not modify it. Re-run tsoa to re-generate this file: https://github.com/lukeautry/tsoa

            let validatedArgs: any[] = [];
            try {
                validatedArgs = templateService.getValidatedArgs({ args: argsProdutoController_getProdutos, request, response });

                const controller = new ProdutoController();

              await templateService.apiHandler({
                methodName: 'getProdutos',
                controller,
                response,
                next,
                validatedArgs,
                successStatus: undefined,
              });
            } catch (err) {
                return next(err);
            }
        });
        // WARNING: This file was auto-generated with tsoa. Please do not modify it. Re-run tsoa to re-generate this file: https://github.com/lukeautry/tsoa
        const argsProdutoController_getProdutoById: Record<string, TsoaRoute.ParameterSchema> = {
                id: {"in":"path","name":"id","required":true,"dataType":"double"},
        };
        app.get('/produtos/:id',
            ...(fetchMiddlewares<RequestHandler>(ProdutoController)),
            ...(fetchMiddlewares<RequestHandler>(ProdutoController.prototype.getProdutoById)),

            async function ProdutoController_getProdutoById(request: ExRequest, response: ExResponse, next: any) {

            // WARNING: This file was auto-generated with tsoa. Please do not modify it. Re-run tsoa to re-generate this file: https://github.com/lukeautry/tsoa

            let validatedArgs: any[] = [];
            try {
                validatedArgs = templateService.getValidatedArgs({ args: argsProdutoController_getProdutoById, request, response });

                const controller = new ProdutoController();

              await templateService.apiHandler({
                methodName: 'getProdutoById',
                controller,
                response,
                next,
                validatedArgs,
                successStatus: undefined,
              });
            } catch (err) {
                return next(err);
            }
        });
        // WARNING: This file was auto-generated with tsoa. Please do not modify it. Re-run tsoa to re-generate this file: https://github.com/lukeautry/tsoa
        const argsPedidoController_getPedidos: Record<string, TsoaRoute.ParameterSchema> = {
        };
        app.get('/pedidos',
            ...(fetchMiddlewares<RequestHandler>(PedidoController)),
            ...(fetchMiddlewares<RequestHandler>(PedidoController.prototype.getPedidos)),

            async function PedidoController_getPedidos(request: ExRequest, response: ExResponse, next: any) {

            // WARNING: This file was auto-generated with tsoa. Please do not modify it. Re-run tsoa to re-generate this file: https://github.com/lukeautry/tsoa

            let validatedArgs: any[] = [];
            try {
                validatedArgs = templateService.getValidatedArgs({ args: argsPedidoController_getPedidos, request, response });

                const controller = new PedidoController();

              await templateService.apiHandler({
                methodName: 'getPedidos',
                controller,
                response,
                next,
                validatedArgs,
                successStatus: undefined,
              });
            } catch (err) {
                return next(err);
            }
        });
        // WARNING: This file was auto-generated with tsoa. Please do not modify it. Re-run tsoa to re-generate this file: https://github.com/lukeautry/tsoa
        const argsPedidoController_getPedidosById: Record<string, TsoaRoute.ParameterSchema> = {
                id: {"in":"path","name":"id","required":true,"dataType":"double"},
        };
        app.get('/pedidos/:id',
            ...(fetchMiddlewares<RequestHandler>(PedidoController)),
            ...(fetchMiddlewares<RequestHandler>(PedidoController.prototype.getPedidosById)),

            async function PedidoController_getPedidosById(request: ExRequest, response: ExResponse, next: any) {

            // WARNING: This file was auto-generated with tsoa. Please do not modify it. Re-run tsoa to re-generate this file: https://github.com/lukeautry/tsoa

            let validatedArgs: any[] = [];
            try {
                validatedArgs = templateService.getValidatedArgs({ args: argsPedidoController_getPedidosById, request, response });

                const controller = new PedidoController();

              await templateService.apiHandler({
                methodName: 'getPedidosById',
                controller,
                response,
                next,
                validatedArgs,
                successStatus: undefined,
              });
            } catch (err) {
                return next(err);
            }
        });
        // WARNING: This file was auto-generated with tsoa. Please do not modify it. Re-run tsoa to re-generate this file: https://github.com/lukeautry/tsoa
        const argsPedidoController_createPedido: Record<string, TsoaRoute.ParameterSchema> = {
                data: {"in":"body","name":"data","required":true,"ref":"PedidoCreateDTO"},
        };
        app.post('/pedidos',
            ...(fetchMiddlewares<RequestHandler>(PedidoController)),
            ...(fetchMiddlewares<RequestHandler>(PedidoController.prototype.createPedido)),

            async function PedidoController_createPedido(request: ExRequest, response: ExResponse, next: any) {

            // WARNING: This file was auto-generated with tsoa. Please do not modify it. Re-run tsoa to re-generate this file: https://github.com/lukeautry/tsoa

            let validatedArgs: any[] = [];
            try {
                validatedArgs = templateService.getValidatedArgs({ args: argsPedidoController_createPedido, request, response });

                const controller = new PedidoController();

              await templateService.apiHandler({
                methodName: 'createPedido',
                controller,
                response,
                next,
                validatedArgs,
                successStatus: undefined,
              });
            } catch (err) {
                return next(err);
            }
        });
        // WARNING: This file was auto-generated with tsoa. Please do not modify it. Re-run tsoa to re-generate this file: https://github.com/lukeautry/tsoa

    // WARNING: This file was auto-generated with tsoa. Please do not modify it. Re-run tsoa to re-generate this file: https://github.com/lukeautry/tsoa


    // WARNING: This file was auto-generated with tsoa. Please do not modify it. Re-run tsoa to re-generate this file: https://github.com/lukeautry/tsoa
}

// WARNING: This file was auto-generated with tsoa. Please do not modify it. Re-run tsoa to re-generate this file: https://github.com/lukeautry/tsoa
