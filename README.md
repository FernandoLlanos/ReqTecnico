# Requerimiento Técnico

Test de Req Técnico FullStack .NET / Angular 8.
Carpetas disponibles:

  - BackEnd (.NET)
  - FrontEnd (Angular v8)
  - BD (SQL Server)
  - Publicacion

### Requerimientos

Requisitos necesarios para instalación y ejecución:

* Para instalar node y npm, vaya a http://nodejs.org/
* Descargue e instale GIT para su plataforma desde http://git-scm.com/downloads
* Abra una consola / terminal y ejecúte npm install -g @angular/clipara instalar el cliente angular para administrar la aplicación.
    ```sh
    $ npm install -g @angular/cli
    ```

## Installation

### Base de Datos (SQL Server)
Abrir la carpeta BD/Scripts y ejecutar los scripts en el orden indicado:
 1. Schema.sql
 2. Store Procedure.sql
### FrontEnd
Abrir la carpeta FrontEnd/WebTest o posicionarse en ese nivel con el terminal integrado de visual studio code.

Descargar las dependencias y librerias mediante el npm.

```sh
$ npm install
```

Iniciar el proyecto

```sh
$ npm start
```
Abrir un navegador web la siguiente URL: http://localhost:4200

### BackEnd

* Abrir la solución slnBackEnd.sln del proyecto ubicado en la ruta: BackEnd/slnBackEnd 
* Compilar y ejecutar
* los servicios rest serán accesibles desde la url: http://localhost:5000
* Para cambiar la cadena de conexión de la base de datos, debe ser desde la capa Infraestructura/Util/Conexion.cs


### Documentación de WEB API mediante Swagger
Para mas referencia: https://swagger.io/tools/swagger-ui/
Para ver los servicios publicados mediante esta herramienta será accesible desde: http://localhost:5000/swagger



