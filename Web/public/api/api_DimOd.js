"use strict"

import express from 'express'
import mysql from 'mysql2/promise'
import fs from 'fs'

const app = express()
const port = 5235

app.use(express.json())

app.use('/js', express.static('./js'))
app.use('/css', express.static('./css'))

async function connectToDB()
{
    return await mysql.createConnection({
        host:'localhost',
        user:'colaborator',
        password:'Adm1nAdm1n**',
        database:'dimensionalOdyssey'
    })
}

app.get('/', (request,response)=>{
    fs.readFile('./html/statistics.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err)
        console.log('Loading page...')
        response.send(html)
    })
})

app.get('/api/users', async (request, response)=>{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from usuario')

        console.log("QWERTY")
        response.json(results)
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


app.listen(port, ()=>
{
    console.log(`App listening at http://localhost:${port}`)
})