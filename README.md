# azure-labs
Laboratorio Azure: functions, Blob Storage, Azure service bus



## Azure bus
**[Azure bus](bus-azure-sender/)**-

Ejemplo de azure bus simulator montado con docker compose. Solo se monta en docker el bus. Esto esta pensado para debuggear y hacer pruebas con los buses.

Se compone de un sender que se ejecuta en local y una azure function que escucha en el topic.

¿Cómo ejecutar?

```bash
## levantar el bus en docker
docker compose up -d

## azure function
func start
## sender 
dotnet run
```

### Comando para crear una función Azure en local

Para creear y ejecutar funciones azure en local en modo desarrollo, se hace con la herramienta [Azure Function Tool](https://learn.microsoft.com/es-es/azure/azure-functions/functions-core-tools-reference?tabs=v2%2Cdotnet&pivots=func-cli-v4)
que previamente deberás instalar.

```
func init ServiceBusFunctions --worker-runtime dotnet-isolated --target-framework net10.0
cd ServiceBusFunctions
func new --template "Service Bus Topic trigger" --name WaitingDniFunction
```
## Ejemplo docker bus-azure-function

Ejemplo que se ejecuta todo en docker . **[bus-azure-function](bbus-azure-function/)**-.

Hay una función azure con un triger que envia un evento a una cola.

Otra Azure Function escucha el bus y procesa el evento.