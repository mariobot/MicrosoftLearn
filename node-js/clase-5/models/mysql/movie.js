// Como leer un json en ESModules
import mysql from 'mysql2/promise'
import dotenv from "dotenv"

const config = {
   host: 'localhost',
   port: 3306,
   user: 'root',
   password: '',
   database: 'moviesdb'
}

// load Database URL from config env
dotenv.config({path: 'dev.env'})
const DATABASE_URL= process.env.DATABASE_URL

const connection = await mysql.createConnection(DATABASE_URL)


export class MovieModel {
    static async getAll ({genre}) { 
        const [movies] = await connection.query(
            'SELECT title, year, director, duration, poster, id FROM movie'
        )

        return movies
    }

    static async getById({id}){
        
    }

    static async createMovie(input){

    }    

    static async updateMovie({id, input}){
        
    }

    static async deleteMovie({id}){
        
    }
}