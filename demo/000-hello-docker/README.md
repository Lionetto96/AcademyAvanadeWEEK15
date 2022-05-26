# Docker 01 - Pull, Create, Start e Stop

## Scaricamento immagine, creazione container e avvio

```sh
# Scaricamento di dell'immagine "hello-world"
docker pull hello-world

# Visualizzazione delle immagini presenti
docker images

# Creazione di un container usando l'immagine, con rimappatura delle porte
docker create --name my-hello-world -p 5080:80 hello-world

# Avvio del container in modalità interattiva (-i); se si desidera
# la modalità "daemon" l'opzione dal utilizzare è "-d"
docker start -i my-hello-world

# Stop del container (nel caso in cui fosse ancora avviato)
docker stop my-hello-world

# Rimozione di tutti i container stoppati
docker container prune
```