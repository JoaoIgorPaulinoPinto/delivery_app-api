import cors from "cors";
import express from "express";
import swaggerUi from "swagger-ui-express";
import swaggerDocument from "./docs/swagger.json";
import { RegisterRoutes } from "./routes/routes"; // Gerado automaticamente pelo TSOA
const app = express();
app.use(
  cors({
    origin: "*", // ou "*" para liberar tudo (apenas dev)
    credentials: true,
  })
);
app.use(express.json());
app.use(express.urlencoded({ extended: true }));

// Swagger UI (http://localhost:3000/docs)
app.use("/docs", swaggerUi.serve, swaggerUi.setup(swaggerDocument));

// Rotas automáticas do TSOA
RegisterRoutes(app);

export default app;
