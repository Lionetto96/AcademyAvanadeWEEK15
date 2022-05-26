# Docker 02 - Creazione di un container e sua modifica

```sh
# Creazione di un container su porta 5080 (locale) mappata su porta 
# 80 (container). L'immagine non presente localmente viene scaricata dal registry
docker create --name my-nginx -p 5080:80 nginx:alpine

# Avvio del container 
docker start my-nginx

# Arresto del container e cancellazione dello stesso
docker stop my-nginx
docker rm my-nginx

# Copia di un file locale nel container, specificando il percorso
# del file locale, il nome del container ":" il percorso completo
# del file di destinazione all'interno del container stesso
docker cp ./02/index.html my-nginx:/usr/share/nginx/html/index.html
```