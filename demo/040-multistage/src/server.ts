import express from 'express';

// Creazione di una app Express
const app = express();

// Esposizione della porta
const port: number = 3000;

// Gestione della chiamata base
app.get('/', (req, res) => {
    console.log(`Chiamato http://localhost:${port}...`);
    res.send('Hello World from multistage build container!');
});

// Avvio del listening sulla porta
app.listen(port, function () {
    console.log(`Example app listening at http://localhost:${port}...`);
});