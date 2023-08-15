const express = require('express')
const crypto = require('node:crypto')
const cors = require('cors')
const movies = require('./movies.json')
const movie = require('./movie')

const app = express()
app.use(express.json())
app.use(cors())
app.disable('x-powered-by')

app.get('/movies', (req,res) =>{    
    const { genre } = req.query
    if( genre ){
        const moviesByGenre = movies.filter(movie => movie.genre.some(g => g.toLocaleLowerCase() == genre.toLocaleLowerCase()))
        return res.json(moviesByGenre)
    }
    return res.json(movies)
})

app.get('/movies/:id', (req, res) =>{ //path-to-regex
    const { id } = req.params
    const movie = movies.find(movie => movie.id === id)
    if(movie) return res.json(movie)
    return res.status(404).json({ message: 'Movie not found'})
})

app.post('/movies/', (req, res) =>{        
    const result = movie.ValidateMovie(req.body)

    if(result.error){
        return res.status(400).json({error: JSON.parse(result.error.message)})
    }
    
    const newMovie = {
        id: crypto.randomUUID(), // generate the GUID
        ...result.data
    }   

    movies.push(newMovie)

    return res.status(201).json(newMovie)
})

app.patch('/movies/:id', (req, res) =>{    
    const result = movie.ValidatePartialMovie(req.body)  
    if(result.error){
        return res.status(400).json({error: JSON.parse(result.error.message)})
    }   
    
    const { id } = req.params
    const movieIndex = movies.findIndex(movie => movie.id === id)

    if(movieIndex === -1){
        return res.status(404).json({ message: 'Movie not found'})
    }

    const updateMovie = {
        ...movies[movieIndex],
        ...result.data
    }

    movies[movieIndex] = updateMovie

    return res.json(updateMovie)
})

const PORT = process.env.PORT ?? 3100

app.listen(PORT, () =>{
    console.log(`server listening on port: http://localhost:${PORT}`)
})

