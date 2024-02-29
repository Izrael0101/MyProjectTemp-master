#### MyProjectTemp

Este proyecto es un ejemplo de una aplicación web que utiliza .NET 8 Rest API con Repositorios y Unit of Work, ADO.NET y Dapper en su proyecto API. El proyecto web utiliza .NET Core 2.1 para consumir la API.

#### Requisitos previos

- [.NET Core 2.1](https://dotnet.microsoft.com/download/dotnet-core/2.1) debe estar instalado en tu máquina.

#### Configuración del proyecto API

1. Clona el repositorio de MyProjectTemp en tu máquina local.
2. Abre el proyecto API en tu IDE preferido.
3. Configura la cadena de conexión a tu base de datos en el archivo `appsettings.json`.
4. Ejecuta las migraciones para crear la base de datos utilizando el comando `dotnet ef database update`.
5. Ejecuta el proyecto API utilizando el comando `dotnet run`.

#### Configuración del proyecto web

1. Abre el proyecto web en tu IDE preferido.
2. Configura la URL de la API en el archivo `appsettings.json`.
3. Ejecuta el proyecto web utilizando el comando `dotnet run`.

#### Uso de la API

La API proporciona los siguientes endpoints:

- `/api/usuarios`: Permite obtener la lista de usuarios.
- `/api/usuarios/{id}`: Permite obtener un usuario específico por su ID.
- `/api/usuarios`: Permite crear un nuevo usuario.
- `/api/usuarios/{id}`: Permite actualizar un usuario existente.
- `/api/usuarios/{id}`: Permite eliminar un usuario existente.

Puedes utilizar herramientas como Postman o cURL para realizar solicitudes HTTP a la API y probar los diferentes endpoints.

#### Contribución

Si deseas contribuir a este proyecto, sigue los siguientes pasos:

1. Haz un fork de este repositorio.
2. Crea una rama con el nombre de tu nueva funcionalidad o corrección de errores.
3. Realiza tus cambios y realiza commits en tu rama.
4. Envía un pull request a la rama principal del repositorio.

#### Soporte

Si tienes alguna pregunta o problema, no dudes en abrir un issue en este repositorio.

Fuentes:
- Documentación oficial de .NET Core: https://dotnet.microsoft.com/
- Documentación oficial de ASP.NET Core: https://docs.microsoft.com/aspnet/core
- Documentación oficial de Dapper: https://dapper-tutorial.net/
- Documentación oficial de ADO.NET: https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/
