# Requerimiento Técnico

Test de Req Técnico FullStack .NET / Angular 8.

Demo Test desplegado en AWS: http://ec2-3-16-215-35.us-east-2.compute.amazonaws.com/

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

```sh
+---dist
+---e2e
+---node_modules
+---src
    +---app
    |   +---core
    |   |   +---menu
    |   |   +---preloader
    |   |   +---settings
    |   |   +---themes
    |   |   +---translator
    |   +---layout
    |   |   +---footer
    |   |   +---header
    |   |   |   +---navsearch
    |   |   +---offsidebar
    |   |   +---sidebar
    |   |       +---userblock
    |   +---routes
    |   |   +---home
    |   |   |   +---home
|   |   +---busqueda
    |   |   |   +---busqueda
    |   +---shared
    |       +---colors
    |       +---directives
    |       |   +---checkall
    |       |   +---easypiechart
    |       |   +---flot
    |       |   +---jqcloud
    |       |   +---now
    |       |   +---scrollable
    |       |   +---sparkline
    |       |   +---vectormap
    |       +---styles
    |           +---app
    |           +---bootstrap
    |           +---themes
    +---assets
    |   +---i18n
    |   +---img
    |   +---server
    +---environments
```

Descargar las dependencias y librerias mediante el npm.

```sh
$ npm install
```

Iniciar el proyecto

```sh
$ npm start
```
Abrir un navegador web la siguiente URL: http://localhost:4200

### BackEnd(RestFul)

* Abrir la solución slnBackEnd.sln del proyecto ubicado en la ruta: BackEnd/slnBackEnd 
* Compilar y ejecutar
* los servicios rest serán accesibles desde la url: http://localhost:5000
* Para cambiar la cadena de conexión de la base de datos, debe ser desde la capa Infraestructura/Util/Conexion.cs


### Documentación de WEB API mediante Swagger
Para mas referencia: https://swagger.io/tools/swagger-ui/
Para ver los servicios publicados mediante esta herramienta será accesible desde: http://localhost:5000/swagger

### Indicaciones sobre el desarrollo.
* Se creó dos tablas TBL_Peronas y TBL_Evaluacion que son la cabecera y detalle, cuando se registra la primera calificación se graba los datos de la persona y su calificación en las tablas correspondientes, a la segunda vez solo guarda en la tabla detalle, para verificar si el usuario ya fue registrado se utiliza el correo electrónico.

* Dentro de la solución del proyecto BackEnd se creó un proyecto un Web API para exponer los servicios RestFul(por comodidad y mejor integración con proyectos angular se utilizaron estos servicios para la integracion con el proyecyo FrontEnd)98.

* Se creó un proyecto WCF para crear servicios SOAP pero no son consumidos en el proyecto FrontEnd.

* Se desarrollaron pruebas unitarias basicas a los servicios construidos.


