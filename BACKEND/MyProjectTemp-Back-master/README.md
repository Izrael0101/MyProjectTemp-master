
# MiProyectoTemp

## Descripción General

MiProyectoTemp es una solución robusta de API REST diseñada con una arquitectura limpia en Visual Studio 2022. Este proyecto enfatiza la mantenibilidad y escalabilidad, aprovechando las mejores prácticas como el patrón de Repositorio, Unidad de Trabajo e Inyección de Dependencias para asegurar la facilidad de manejo de entidades y operaciones de la base de datos.

## Estructura

- **MiProyectoTemp.Api**: El punto de entrada para la capa API, maneja todas las solicitudes y respuestas HTTP. Incluye Controladores para el enrutamiento y DTOs para los objetos de transferencia de datos.

- **MiProyectoTemp.App**: Contiene Interfaces que definen contratos para servicios e interacciones de repositorio.

- **MiProyectoTemp.Core**: Aloja la lógica de negocio e incluye Entidades que representan modelos de datos y una carpeta Compartida para recursos comunes.

- **MiProyectoTemp.Infra**: Implementa el patrón de Repositorio y la Unidad de Trabajo. Incluye `ServiceCollectionExtension.cs` para configurar servicios e inyección de dependencias.

- **MiProyectoTemp.Sql**: Gestiona las interacciones de la base de datos SQL, especialmente con Procedimientos Almacenados para manejar transacciones de manera más efectiva utilizando ADO.Net con Dapper, un micro-ORM.

- **MiProyectoTemp.Tests**: Contiene todas las pruebas unitarias e integración para asegurar la fiabilidad y calidad del código.

## Componentes Adicionales

- **Carpeta Postman**: No se usa dentro de Visual Studio pero contiene colecciones de Postman para el testing e interacción con la API.

- **Carpeta NodeJs**: Utiliza una configuración de ReverseProxy usando Express y `http-proxy-middleware`. Manejado a través de PM2 para la gestión de procesos.

## Desarrollo

Desarrollado con Visual Studio 2022, este proyecto está estructurado para hacer uso de las características modernas proporcionadas por el entorno .NET. Se recomienda tener las últimas actualizaciones de Visual Studio y .NET SDK para una experiencia de desarrollo sin problemas.

## Dependencias

- ADO.Net con Dapper para interacciones con la base de datos
- PM2, Express y `http-proxy-middleware` para el ReverseProxy de NodeJs

## Configuración

1. Clonar el repositorio.
2. Abrir la solución en Visual Studio 2022.
3. Asegurarse de que todos los paquetes NuGet estén restaurados.
4. Configurar la base de datos utilizando los scripts proporcionados en el directorio MyProjectTemp.Sql/Scripts.
5. Instalar las dependencias de NodeJs con `npm install` en el directorio de NodeJs.
6. Configurar el ReverseProxy según sea necesario.
7. Ejecutar el proyecto API.

## Uso

Para probar la API, utilice las colecciones de Postman proporcionadas para ejecutar solicitudes. Para entornos de producción, configure el ReverseProxy para un rendimiento y seguridad óptimos.

---

Este README describe la estructura básica y la configuración para el proyecto MiProyectoTemp. Es recomendable incluir documentación adicional sobre los puntos finales de la API, ejemplos de uso y pautas de contribución para los desarrolladores.
