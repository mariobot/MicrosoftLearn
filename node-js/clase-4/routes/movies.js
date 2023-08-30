import { Router } from "express";
import { MovieController } from "../controllers/movies.js";

// Como leer un json en ESModules
import { createRequire } from 'node:module'
const require = createRequire(import.meta.url)
const movies = require('../movies.json')

export const movieRouter = Router()

movieRouter.get('/', MovieController.getAll)
movieRouter.post('/', MovieController.createMovie)

movieRouter.get('/:id', MovieController.getById)
movieRouter.delete('/:id', MovieController.deleteMovie)
movieRouter.patch('/:id', MovieController.updateMovie)