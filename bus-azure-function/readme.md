Este proyecto es un lab-test para probar las funciones azure contra un bus. 

Se compone de: 
* GenerateOrderFunction función azure con trigger para enviar eventos a un bus
* ProcessOrderFunction función azure que escucha en ese bus y procesa
* azurite con mssql server para almacenar las azure functions
* además hay un producer dummy que envia eventos

# Ejecución
Levantar con docker compose up -d

Una vez levantado ejecutar Event Producer para enviar un evento

escuchar logs en docker docker compose logs -f function




