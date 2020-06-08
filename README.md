# VoiceMod

## Lanzar Aplicación
1. Clonar solución
2. Desde la carpeta raiz de la solución ejecutar comando `dotnet run --project Voicemod.Users.Api`
3. En la ventana de comandos aparecerá `Now listening on: https://localhost:XXXX`
4. Navigate to `https://localhost:XXXX/swagger` para acceder a la interfaz swagger de la Api

## Información Técnica
He seguido el enfoque *Domain Driven Design* junto con una arquitectura hexagonal para implementar el sistema. 

La Api se ha estructurado y definido siguiendo el standard *REST* 

Se ha implementado el patrón repositorio para desacoplar la capa de dominio de la capa de persistencia, por lo tanto, se podría usar cualquier tipo de sistema de persistencia, únicamente habría que proporcionar la correspondiente implementación del repositorio utilizando el sistema de persistencia elegido (SQL Server, MySql, MongoDb, ...). Al tratarse una prueba técnica, he optado por usar una base de datos *In Memory* usando *Entity Framework Core*, por lo tanto hay que tener en cuenta que una vez se detenga la aplicación los datos persistidos durante la ejecución de la misma se perderán.

Para darle un poco de sentido al endpoint de *Login* de usuario me he tomado la libertad de definir todas las operaciones como privadas salvo la creación de usuarios y el login de usuario. De esta manera, se podrá invocar anónimamente la acción *Post* de creación de usuarios para poder crear un usuario cualquiera (emulando un registro de usuario). Posteriormente se deberá invocar la acción de login para obtener el token JWT que nos permitirá autenticarnos para invocar el resto de operaciones. Se ha habilitado en la interfaz *swagger* de la API una opción para poder introducir el token obtenido en el *body* de la respuesta de la petición de *login*. Pulsando en el botón *Authorize* en la parte superior derecha se abrirá una ventana modal donde podremos introducir nuestro token e invocar así el resto de operaciones sin problema.


