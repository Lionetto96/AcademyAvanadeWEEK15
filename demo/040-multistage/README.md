# Docker 05 - Multistage build

1) Creazione di una nuova applicazione NodeJs basata su TypeScript
   - `npm init`
   - `npm install -D typescript`
   - `npm install -D tslint`
   - `npm install -S express`
   - `npm install -D @types/express`

2) Creazione del file di configurazione `tsconfig.json` del TypeScript compiler 

```json
{
  "compilerOptions": {
    "module": "commonjs",
    "esModuleInterop": true,
    "target": "es6",
    "moduleResolution": "node",
    "sourceMap": true,
    "outDir": "dist"
  },
  "lib": ["es2015"]
}
```

3) Copia del file `server.ts` nella cartella `src`

4) Creare il file di configurazione `tslint.json` per TS Linter

```json
{
  "defaultSeverity": "error",
  "extends": ["tslint:recommended"],
  "jsRules": {},
  "rules": {
    "no-console": false
  },
  "rulesDirectory": []
}
```

5) Aggiunta della sezione `scripts` nel file `package.json`

```json
{
  ...
  "scripts": {
    "build": "tsc",    
    "lint": "./node_modules/.bin/tslint ./src/server.ts",
    "start": "tsc && node dist/server.js"
  },
  ...
}
```

6) Aggiunta del file `.dockerignore` per evitare il caricamento
nelle immagini delle cartelle `node_modules` e `dist`

7) Definizione del `Dockerfile` nella root

8) Creazione immagine Docker 
   - `docker image build -t maurobussini/docker-demo-05:latest --no-cache .`

9) Verifica dello stato dell'immagine creata
   - `docker images`

10) Creazione del container basato sull'immagine
    - `docker container run --name my-docker-demo-05 -p 3000:3000 -d maurobussini/docker-demo-05:latest`