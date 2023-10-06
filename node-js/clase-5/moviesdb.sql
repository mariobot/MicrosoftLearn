
-- Create table movies
create table movie(
 id varchar(255) primary key default(uuid()),
 title varchar(255) not null,
 year int not null,
 director varchar(255) not null,
 duration int not null,
 poster text,
 rate decimal(2,1) unsigned not null
);

create table genre(
	id int auto_increment primary key,
    name varchar(255) not null unique
);

create table movie_genres(
	movie_id varchar(255) references movies(id),
    genre_id int references genre(id),
    primary key (movie_id,genre_id)
);

insert into genre(name) values
('Drama'),
('Action'),
('Crime'),
('Adventure'),
('Sci-Fi'),
('Romance');

insert into movie(id, title, year, director, duration, poster, rate) values
((select uuid()), "Inception", 2010, "Cristopher Nolan", 180, "https://m.media-amazon.com/images/I/91Rc8cAmnAL._AC_UF1000,1000_QL80_.jpg",8.8),
((select uuid()), "Pulp Fiction", 1994, "Quentin Tarantino", 154, "https://www.themoviedb.org/t/p/original/vQWk5YBFWF4bZaofAbv0tShwBvQ.jpg",8.9),
((select uuid()), "Forrest Gump", 1994, "Robert Zemeckis", 180, "https://i.ebayimg.com/images/g/qR8AAOSwkvRZzuMD/s-l1600.jpg",8.8),
((select uuid()), "Gladiator", 2000, "Ridley Scott", 155, "https://img.fruugo.com/product/0/60/14417600_max.jpg",8.5),
((select uuid()), "The Matrix", 1999, "Lana Wachowski", 136, "https://i.ebayimg.com/images/g/QFQAAOSwAQpfjaA6/s-l1200.jpg",8.7);

insert into movie_genres (movie_id, genre_id) values
((select id from movie where title = 'Inception'),(select id from genre where name = 'Sci-Fi')),
((select id from movie where title = 'Inception'),(select id from genre where name = 'Action')),
((select id from movie where title = 'Pulp Fiction'),(select id from genre where name = 'Action')),
((select id from movie where title = 'Forrest Gump'),(select id from genre where name = 'Drama')),
((select id from movie where title = 'Gladiator'),(select id from genre where name = 'Drama')),
((select id from movie where title = 'The Matrix'),(select id from genre where name = 'Action'));

select * from movie;

