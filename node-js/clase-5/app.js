import express, { json } from 'express'
import cors from 'cors'
import { movieRouter } from './routes/movies.js'

const app = express()
app.use(json())
app.use(cors())
app.disable('x-powered-by')

app.use('/movies', movieRouter)

const PORT = process.env.PORT ?? 3100

app.listen(PORT, () =>{
    console.log(`server listening on port: http://localhost:${PORT}`)
})

