Ejemplo de Azure Function con HTTP Trigger

Creación

```
func init HttpFunctions --worker-runtime dotnet-isolated
cd HttpFunctions
func new --template "HTTP trigger" --name HelloFunction
``` 

Se lanza con una petición http: curl http://localhost:7071/api/HelloFunction