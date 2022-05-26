# Immagine di partenza (NodeJs, tag su versione 12)
FROM node:12

# Lancio di un comando nel container (per creazione directory di lavoro)
RUN mkdir -p /usr/src/app

# Copia dalla folder del computer locale, alla directory di lavoro del container
COPY . /usr/src/app

# Directory di lavoro (interna al container)
WORKDIR /usr/src/app

# Restore delle dipendenze nel container
RUN npm install

# Esposizione della porta (3000, la stessa di Express)
EXPOSE 3000

# Comando di avvio del container: ATTENZIONE a non fare "RUN"!!!
CMD [ "node", "server.js" ]





