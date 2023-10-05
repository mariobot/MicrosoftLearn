// Como leer un json en ESModules
import { createRequire } from 'node:module'
import { randomUUID } from 'node:crypto'
const require = createRequire(import.meta.url)
const movies = require('../movies.json')

export class MovieModel {
    static async getAll ({genre}) { 
        if(genre) {
            return movies.filter(movie => movie.genre.some(g => g.toLocaleLowerCase() == genre.toLocaleLowerCase()))
        }
        return movies
    }

    static async getById({id}){
        console.log(id)
        return movies.find(movie => movie.id === id)
    }

    static async createMovie(input){
        const newMovie = {
            id: randomUUID(), // generate the GUID
            ...input
        }   
    
        movies.push(newMovie)
        return newMovie
    }    

    static async updateMovie({id, input}){
        const movieIndex = movies.findIndex(movie => movie.id === id)

        if(movieIndex === -1) return false

        const updateMovie = {
            ...movies[movieIndex],
            ...input
        }
    
        movies[movieIndex] = updateMovie

        return movies[movieIndex]
    }

    static async deleteMovie({id}){
        const movieIndex = movies.findIndex(movie => movie.id === id)
        if(movieIndex === -1) return false

        movies.splice(movieIndex, 1)
        return true
    }
}