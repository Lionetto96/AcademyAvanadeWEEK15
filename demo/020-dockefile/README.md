# Docker 03 - L'utilizzo di Dockerfile

1) Creazione nuova applicazione NodeJs 
   - `npm init`

2) Creazione file `server.js` nella root

3) Installazione di Express 
   - `npm install -S express`

4) Scrittura del codice della Express application
   - https://expressjs.com/it/starter/hello-world.html

5) Aggiunta dello script di avvio "start"
    - `"start" : "node server.js"`

5) Creazione `Dockerfile` nella root

6) Creazione immagine Docker 
   - `docker image build -t maurobussini/docker-demo-03:latest --no-cache .`

7) Verifica dello stato dell'immagine creata
   - `docker images`

8) Push dell'immagine sul Docker Hub
   - `docker image push maurobussini/docker-demo-03:latest`

9) Docker login (se non ancora connessi)

10) Scaricamento immagine e avvio del container
    - `docker container run --name my-docker-demo-03 -p 3000:3000 -d maurobussini/docker-demo-03:latest`
    - Opzione `-p 3000:3000` per mappatura porta su host
    - Opzione `-d` per esecuzione come "demone"
    - Opzione `-n my-docker-demo-03` nome del container