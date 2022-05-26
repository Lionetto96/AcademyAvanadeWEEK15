const express = require('express');
const handlebars = require('express-handlebars');
const os = require("os");
const morgan  = require('morgan');

const app = express();

app.engine('handlebars', handlebars({defaultLayout: 'main'}));
app.set('view engine', 'handlebars');
app.use(express.static('static'));
app.use(morgan('combined'));


const port = process.env.PORT || 3000;
const message = process.env.MESSAGE || "Hello from Docker Container!";

app.get('/', (req, res) => {
  res.render('home', {
    message: message,
    hostName: os.hostname()
  });
})

app.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port} from host ${os.hostname()}`);
})
