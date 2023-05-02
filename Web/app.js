"use strict"

import compression from 'compression';
import express from 'express';
import fs from 'fs';
import mysql from 'mysql2/promise';
import session from 'express-session';

const app = express()


const port = 5235

app.use(compression())
app.use(express.json())
app.use(express.static('./public'))

let active_session = null;


async function connectToDB() {
    return await mysql.createConnection({
        host: 'localhost',
        user: 'colaborator',
        password: 'Adm1nAdm1n**',
        database: 'dimensionalodyssey'
    })
}

app.use(session({
    secret: '!hJZb3k?S^tN9M=+', // Una clave secreta para firmar la cookie de sesión
    resave: false, // Evita que se vuelva a guardar la sesión si no ha sido modificada
    saveUninitialized: false, // Evita que se cree una sesión para las solicitudes que no la tienen
  }));

app.use((req, res, next) => {
    const { username } = req.session;
    if (username) {
      res.setHeader('Set-Cookie', `username=${username}; Path=/`);
    }
    next();
});

app.get('/', (request, response) => {
    fs.readFile('./public/html/index.html', 'utf8', (err, html) => {
        if (err) response.status(500).send('There was an error: ' + err)
        console.log('Loading page...')
        response.send(html)
    })
})

app.get('/api/usuario', async (request, response) => {
    let connection = null

    try {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from usersList')

        console.log("QWERTY")
        console.log(results)
        response.json(results)
    }
    catch (error) {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally {
        if (connection !== null) {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

app.post('/api/login', async (req, res) => {
    const { username, password } = req.body;
    let connection = null
    try {
        connection = await connectToDB()
        const [rows] = await connection.execute('select * from usuario where username = ?', [username]);
        console.log('rows:', rows);

        if (rows.length === 0) {
        // El usuario no existe
        return res.status(401).json({ message: 'El usuario no existe' });
        }

        const user = rows[0];
        console.log('Contraseña introducida:', password);
        console.log('Contraseña almacenada:', user.contrasena);
        if (password !== user.contrasena) {
        // La contraseña es incorrecta
        return res.status(401).json({ message: 'La contraseña es incorrecta' });
        }
        active_session = user.username;
        req.session.username = active_session; // Guarda el nombre de usuario en la sesión

        // Si las credenciales son válidas, crear una cookie y establecer su valor como el nombre de usuario
        res.setHeader('Set-Cookie', `username=${user.username}; Path=/`);
        console.log("Cookie establecida:", user.username);

        return res.status(200).json({ message: 'Inicio de sesión exitoso', redirect: '/html/index.html' });

    } catch (err) {
        console.log(err);
        return res.status(500).json({ message: 'Error de servidor' });
    }
  });

  app.get('/api/session', (req, res) => {
    if (req.session.username) {
      // La sesión ha sido iniciada
      res.json({
        loggedIn: true,
        username: req.session.username
      });
    } else {
      // La sesión no ha sido iniciada
      res.json({
        loggedIn: false
      });
    }
  });

app.get('/api/usuario/:id', async (request, response) => {
    let connection = null

    try {
        connection = await connectToDB()

        const [results, fields] = await connection.query('select * from usersList where username= ?', [request.params.id])

        console.log("ADASDA")
        response.json(results)
    }
    catch (error) {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally {
        if (connection !== null) {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

app.get('/api/contpartidas', async (request, response) => {
    let connection = null

    try {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from contPartidas_usuarios')

        console.log("QWERTY")
        response.json(results)
    }
    catch (error) {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally {
        if (connection !== null) {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

app.get('/api/enemigos', async (request, response) => {
    let connection = null

    try {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from contEnemiesKilled')

        console.log("QWERTY")
        console.log(results)
        response.json(results)
    }
    catch (error) {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally {
        if (connection !== null) {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

app.get('/api/damage', async (request, response) => {
    let connection = null

    try {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from usersDamage')

        console.log("QWERTY")
        console.log(results)
        response.json(results)
    }
    catch (error) {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally {
        if (connection !== null) {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

app.get('/api/coins', async (request, response) => {
    let connection = null

    try {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from coinsUsername')

        console.log("QWERTY")
        console.log(results)
        response.json(results)
    }
    catch (error) {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally {
        if (connection !== null) {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

app.post('/api/usuario', async (request, response) => {

    let connection = null

    try {
        connection = await connectToDB()

        const [results, fields] = await connection.query('insert into usuario set ?', request.body)

        response.json({ 'message': "Data inserted correctly." })
    }
    catch (error) {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally {
        if (connection !== null) {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})



app.get('/api/personajes', async (request, response) => {
    let connection = null

    try {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from personajes')

        console.log("QWERTY")
        console.log(results)
        response.json(results)
    }
    catch (error) {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally {
        if (connection !== null) {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

app.get('/api/partida', async (request, response) => {
    let connection = null;
    const username = active_session;
  
    try {
      connection = await connectToDB();
      const [results, fields] = await connection.execute(
        `select * from partida where username = ?`, [username]
      );
  
      console.log(results);
      response.json(results);
    } catch (error) {
      response.status(500);
      response.json(error);
      console.log(error);
    } finally {
      if (connection !== null) {
        connection.end();
        console.log('Connection closed succesfully!');
      }
    }
  });

  app.post('/api/partida', async (request, response) => {

    let connection = null;
    const username = active_session;

    try {
        connection = await connectToDB()

        const [results, fields] = await connection.query('insert into partida (username, fecha) values (?, NOW())', [username])

        response.json({ 'message': "Data inserted correctly." })
    }
    catch (error) {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally {
        if (connection !== null) {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

  /*
app.post('/api/partida', async (request, response) => {

    let connection = null

    try {
        connection = await connectToDB()

        const [results, fields] = await connection.query('insert into partida (username, fecha) values (?, NOW())', request.body['username'])

        response.json({ 'message': "Data inserted correctly." })
    }
    catch (error) {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally {
        if (connection !== null) {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
}) 
app.put('/api/usuario', async (request, response)=>{

    let connection = null

    try{
        connection = await connectToDB()

        const [results, fields] = await connection.query('update usuario set nombre = ?, apellido = ?, contrasena = ?, correo = ?, where username = ?', [request.body['nombre'], request.body['apellido'], request.body['contrasena'], request.body['email'], request.body['username']])
        
        response.json({'message': "Data updated correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})
*/

app.put('/api/personajes', async (request, response) => {

    let connection = null

    try {
        connection = await connectToDB()

        const [results, fields] = await connection.query('update personajes set energia = ?, xp = ?, velocidadMov = ?, velocidadDis = ?, vida = ?, resistencia = ?, recuperacionEn = ?, roboVida = ?, enemiesKilled = ? WHERE idPartida = ?', [request.body['energia'], request.body['xp'], request.body['velocidadMov'], request.body['velocidadDis'], request.body['vida'], request.body['resistencia'], request.body['recuperacionEn'], request.body['roboVida'], request.body['enemiesKilled'], request.body['idPartida']])

        response.json({ 'message': "Data updated correctly." })
    }
    catch (error) {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally {
        if (connection !== null) {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})


app.listen(port, () => {
    console.log(`App listening at http://127.0.0.1:${port}`)
})