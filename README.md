# azure-labs
Laboratorio Azure: functions, Blob Storage, Azure service bus



## Azure bus
**[Azure bus](bus-azure-sender/)**-

Ejemplo de azure bus simulator montado con docker compose. Solo se monta en docker el bus. Esto esta pensado para debuggear y hacer pruebas con los buses.

Se compone de un sender que se ejecuta en local y una azure function que escucha en el topic.

Para levantar la función en local hay que ejecutar y el sender

```bash
## azure function
func start
## sender 
dotnet run
```

### Comando para crear una función Azure en local
```
func init ServiceBusFunctions --worker-runtime dotnet-isolated --target-framework net10.0
cd ServiceBusFunctions
func new --template "Service Bus Topic trigger" --name WaitingDniFunction
```
## Ejemplo docker bus-azure-function

Ejemplo que se ejecuta todo en docker . **[bus-azure-function](bbus-azure-function/)**-.

Hay una función azure con un triger que envia un evento a una cola.

Otra Azure Function escucha el bus y procesa el evento.