# *** BUILD ***
# Immagine di partenza con NodeJs versione 12 
# Battezzo l'immagine come 'build': servirà solo per la costruzione
FROM node:12 as build

# Directory di lavoro che conterrà i sorgenti
WORKDIR /sources

# Copia di tutti i sorgenti, esclusi quelli di .dockerignore
COPY . .

# Restore dei pacchetti NPM
RUN npm install

# Avvio della compilazione del codice TypeScript
RUN npm run build


# *** RUNTIME ***
# Avvio della nuova immagine con solo runtime
FROM node:12 AS runtime

# Applico dei label (chiave-valore) all'immagine finale
LABEL name="Docker MultiStage Demo"
LABEL author="Mauro Bussini"
LABEL it.maurobussini.version="0.0.1"

# Directory di lavoro
WORKDIR /app

# Copia del file package.json e package-lock.json nel container di runtime
COPY --from=build /sources/package*.json ./

# Copia dei file compilati (del container di build) nel container corrente
COPY --from=build /sources/dist ./

# Restore delle sole dipendenze di Produzione (escluse quelle "dev")
RUN npm install --only=production

# Eseguibile di avvio del container
ENTRYPOINT ["node", "server.js"]