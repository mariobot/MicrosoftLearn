import z from 'zod'

const movieSchema = z.object({
    title: z.string(),
    year: z.number().int().positive().min(1900).max(2024),
    director: z.string(),
    duration: z.number().int().positive(),
    rate: z.number().min(0).max(10).default(0),
    poster: z.string().url(),
    genre: z.array(
        z.enum(['Action', 'Adventure', 'Crime','Comedy', 'Drama','Romance','Fantasy','Horror','Thriller','Sci-Fi']),
            { 
                required_error : 'Movie genre is required',
                invalid_type_error : 'Movie genre must be an array of enum Genre'
            }
        )
})

function ValidateMovie(object){
    return movieSchema.safeParse(object)
}

function ValidatePartialMovie(object){
    return movieSchema.partial().safeParse(object)
}

export {
    ValidateMovie,
    ValidatePartialMovie
}