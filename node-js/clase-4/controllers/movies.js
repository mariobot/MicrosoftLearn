import { any } from 'zod';
import { MovieModel } from '../models/movie.js'
import { ValidateMovie, ValidatePartialMovie } from '../movie.js'

export class MovieController {
    static async getAll (req, res){
        const { genre } = req.query
        const movies = await MovieModel.getAll({genre})
        // Que es lo que renderiza
        return res.json(movies)
    }

    static async getById (req, res){
        const { id } = req.params
        const movie = await MovieModel.getById({id})
        if(movie) return res.json(movie)
        return res.status(404).json({ message: 'Movie not found'})
    }

    static async createMovie (req, res){
        const result = ValidateMovie(req.body)

        if(result.error){
            return res.status(400).json({error: JSON.parse(result.error.message)})
        }

        const newMovie = await MovieModel.createMovie(result.data)
        return res.status(201).json(newMovie)
    }

    static async deleteMovie (req, res){
        const { id } = req.params
        const movieDeleted  = await MovieModel.deleteMovie({id})

        if(movieDeleted === false){
            return res.status(404).json({ message: 'Movie not found'})        
        }

        return res.json({ message: 'Movie deleted'})
    }

    static async updateMovie (req, res){
        const result = ValidatePartialMovie(req.body)  
        if(result.error){
            return res.status(400).json({error: JSON.parse(result.error.message)})
        }   
        
        const { id } = req.params
        
        const updateMovie = await MovieModel.updateMovie({id, input: result.data})    

        return res.json(updateMovie)
    }
}