# Turismo Real Login  
Servicio REST utilizado para saber si un usuario se encuentra registrado en el sistema y esta autorizado para loguearse.  
  
## Levantar Servicio
Para poder levantar el servicio localmente, lo primero que se debe asegurar es tener instalado el runtime de .NET Core 3.1 que se puede descargar desde el siguiente enlace *(se recomienda instalar SDK)*: [Runtime y SDK .NET Core 3.1 LTS](https://dotnet.microsoft.com/download).  

### Comprobar instalación de Runtime o SDK  
Abrir una terminal y ejecutar los siguientes comandos, según sea la necesidad. Información extraída de la [documentación de dotnet](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet).
- `dotnet --info`: Obtener información detallada sobre la instalación de .NET en la máquina local.  
- `dotnet --version`: Obtener la versión de .NET SDK.
- `dotnet --list-runtimes`: Obtener lista de los runtimes de .NET instalados en la máquina.
- `dotnet --list-sdks`: Lista los SDKs de .NET instalados en la máquina.

### Compilar y ejecutar servicio desde CLI
Una vez instaladas las herramientas necesarias para la ejecución, el siguiente paso es clonar el repositorio y ubicarse dentro de él, donde se puede encontrar un archivo con la extensión `sln`. En esa ubicación se ejecuta el comando `dotnet build` que comenzará la compilación de la solución.  
  
Una vez compilado, se debe dirigir al directorio `TurismoReal_Login.Api` y dentro ejecutar el comando `dotnet run`.  
Con esto el servicio quedaría corriendo en `http://localhost:5000`.

### Abrir desde Visual Studio
Para abrir el servicio desde visual studio, solamente se debe abrir un proyecto y buscar el archivo que termina con la extensión `sln` y el IDE hace el resto.

---
## Consumir Servicio  
Para consumir el servicio cuando este se encuentra en ejecución, se debe hacer uso de un cliente HTTP como Insomnia o Postman y la manera de consultarlo es la siguiente.  
- **URL:** http://localhost:5001/api/v1/login
- **Method:** POST  
  
**PAYLOAD**
```
{
    "email": "f.donoso@gmail.com",
	"password": "117735823fadae51db091c7d63e60eb0"
}
```  
**RESPUESTA OK**
```
{
  "message": "Usuario Autorizado.",
  "login": true
}
```

**RESPUESTA NOT OK**
```
{
  "message": "Usuario No Autorizado.",
  "login": false
}
```