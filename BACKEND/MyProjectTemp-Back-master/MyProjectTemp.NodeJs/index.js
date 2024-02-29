const express = require('express');
const { createProxyMiddleware } = require('http-proxy-middleware');

const app = express();

// Configuración del reverse proxy para redirigir solicitudes a la API .NET Core
const apiProxy = createProxyMiddleware('/MyProjectTempApi', {
    target: 'http://localhost', // Apunta al host donde tu API está corriendo
    changeOrigin: true,
    pathRewrite: { '^/MyProjectTempApi': '/MyProjectTempApi' }, // No necesita reescribir en este caso
    logLevel: 'debug' // Habilita la depuración para ver qué está pasando
});

app.use('/MyProjectTempApi', apiProxy);

const PORT = 30000;
app.listen(PORT, () => {
    console.log(`Reverse proxy corriendo en http://localhost:${PORT}`);
});