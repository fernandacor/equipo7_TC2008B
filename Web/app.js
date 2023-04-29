"use strict"

import compression from 'compression';
import express from 'express';
import fs from 'fs';
import mysql from 'mysql2/promise';

const app = express()


const port = 5235

app.use(compression())
app.use(express.json())
app.use(express.static('./public'))


async function connectToDB() {
    return await mysql.createConnection({
        host: 'localhost',
        user: 'colaborator',
        password: 'Adm1nAdm1n**',
        database: 'dimensionalodyssey'
    })
}

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

app.post('/api/login', async (request, response) => {
    const { username, password } = request.body
    let connection = null

    try {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from usuario where username = ?', [username])

        if (results.length > 0) {
            const user = results[0]

            if (bcrypt.compareSync(password, user.contrasena)) {
                response.json({ success: true })
            } else {
                response.json({ success: false, message: 'Contraseña incorrecta' })
            }
        } else {
            response.json({ success: false, message: 'Usuario no encontrado' })
        }
    } catch (error) {
        response.status(500)
        response.json(error)
        console.log(error)
    } finally {
        if (connection !== null) {
            connection.end()
            console.log("Conexión cerrada exitosamente!")
        }
    }
})

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

app.get('/api/partidas', async (request, response) => {
    let connection = null

    try {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from contPartidas_usuarios')

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
    let connection = null

    try {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from partida')

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

/*
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
    console.log(`App listening at http://127.0.0.1:${port}/html`)
})