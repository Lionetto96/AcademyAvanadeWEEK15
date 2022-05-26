# Docker 04 - Mappatura delle porte e variabili di ambiente

1) Struttura base della **docker-demo-03**

2) Copia del file `server.js` nella root

3) Installazione di Express e altre dipendenze
   - `npm install -S express`
   - `npm install -S handlebars`
   - `npm install -S express-handlebars`
   - `npm install -S bytes`
   - `npm install -S minimist`
   - `npm install -S morgan`

4) Definizione del `Dockerfile` nella root

5) Creazione immagine Docker 
   - `docker image build -t maurobussini/docker-demo-04:latest --no-cache .`

6) Verifica dello stato dell'immagine creata
   - `docker images`

10) Creazione del container basato sull'immagine
    - `docker container run --name my-docker-demo-04 -p 3000:3000 -d maurobussini/docker-demo-04:latest`
    - Opzione `-p 3000:3000` per mappatura porta su host
    - Opzione `-d` per esecuzione come "demone"
    - Opzione `-n my-docker-demo-04` nome del container

11) Riavviare l'immagine impostando da linea di comando la variabile di ambiente del messaggio (e la porta)
    - `docker container run --name my-docker-demo-04-bis -e MESSAGE="Hello from commandline" -p 3100:3000 -d maurobussini/docker-demo-04:latest`
    - Opzione `-p 3100:3000` per mappatura porta su host locale, porta **3100**
    - Opzione `-e MESSAGE="Hello from commandline"` per impostare una variabile d'ambiente del container