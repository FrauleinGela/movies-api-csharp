namespace MoviesApi.Models
{
    public class MoviesData
    {
        public static void SeedDb(MoviesDbContext context)
        {
            context.Movies.AddRange(new Movie
            {
                Title = "The Shawshank Redemption",
                Year = "1994",
                Rated = "R",
                Released = "14 Oct 1994",
                Runtime = "142 min",
                Genre = "Drama",
                Director = "Frank Darabont",
                Writer = "Stephen King (short story \"Rita Hayworth and Shawshank Redemption\"), Frank Darabont (screenplay)",
                Actors = "Tim Robbins, Morgan Freeman, Bob Gunton, William Sadler",
                Plot = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                Language = "English",
                Country = "USA",
                Awards = "Nominated for 7 Oscars. Another 21 wins & 36 nominations.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SX300.jpg",

                ImdbRating = "9.3",
                ImdbID = "tt0111161"
            },
        new Movie
        {
            Title = "One Flew Over the Cuckoo's Nest",
            Year = "1975",
            Rated = "R",
            Released = "19 Nov 1975",
            Runtime = "133 min",
            Genre = "Drama",
            Director = "Milos Forman",
            Writer = "Lawrence Hauben (screenplay), Bo Goldman (screenplay), Ken Kesey (based on the novel by), Dale Wasserman (the play version= \"One Flew Over the Cuckoo's Nest\" by)",
            Actors = "Michael Berryman, Peter Brocco, Dean R. Brooks, Alonzo Brown",
            Plot = "A criminal pleads insanity and is admitted to a mental institution, where he rebels against the oppressive nurse and rallies up the scared patients.",
            Language = "English",
            Country = "USA",
            Awards = "Won 5 Oscars. Another 30 wins & 15 nominations.",
            Poster = "https://m.media-amazon.com/images/M/MV5BZjA0OWVhOTAtYWQxNi00YzNhLWI4ZjYtNjFjZTEyYjJlNDVlL2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SX300.jpg",

            ImdbRating = "8.7",
            ImdbID = "tt0073486"
        },
        new Movie
        {
            Title = "The Godfather",
            Year = "1972",
            Rated = "R",
            Released = "24 Mar 1972",
            Runtime = "175 min",
            Genre = "Crime, Drama",
            Director = "Francis Ford Coppola",
            Writer = "Mario Puzo (screenplay by), Francis Ford Coppola (screenplay by), Mario Puzo (based on the novel by)",
            Actors = "Marlon Brando, Al Pacino, James Caan, Richard S. Castellano",
            Plot = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
            Language = "English, Italian, Latin",
            Country = "USA",
            Awards = "Won 3 Oscars. Another 26 wins & 30 nominations.",
            Poster = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg",

            ImdbRating = "9.2",
            ImdbID = "tt0068646"
        },
        new Movie
        {
            Title = "The Dark Knight",
            Year = "2008",
            Rated = "PG-13",
            Released = "18 Jul 2008",
            Runtime = "152 min",
            Genre = "Action, Crime, Drama, Thriller",
            Director = "Christopher Nolan",
            Writer = "Jonathan Nolan (screenplay), Christopher Nolan (screenplay), Christopher Nolan (story), David S. Goyer (story), Bob Kane (characters)",
            Actors = "Christian Bale, Heath Ledger, Aaron Eckhart, Michael Caine",
            Plot = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
            Language = "English, Mandarin",
            Country = "USA, UK",
            Awards = "Won 2 Oscars. Another 153 wins & 160 nominations.",
            Poster = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_SX300.jpg",

            ImdbRating = "9.0",
            ImdbID = "tt0468569"
        },
        new Movie
        {
            Title = "Schindler's List",
            Year = "1993",
            Rated = "R",
            Released = "04 Feb 1994",
            Runtime = "195 min",
            Genre = "Biography, Drama, History",
            Director = "Steven Spielberg",
            Writer = "Thomas Keneally (book), Steven Zaillian (screenplay)",
            Actors = "Liam Neeson, Ben Kingsley, Ralph Fiennes, Caroline Goodall",
            Plot = "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.",
            Language = "English, Hebrew, German, Polish, Latin",
            Country = "USA",
            Awards = "Won 7 Oscars. Another 83 wins & 50 nominations.",
            Poster = "https://m.media-amazon.com/images/M/MV5BNDE4OTMxMTctNmRhYy00NWE2LTg3YzItYTk3M2UwOTU5Njg4XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg",

            ImdbRating = "8.9",
            ImdbID = "tt0108052"
        },
        new Movie
        {
            Title = "Pulp Fiction",
            Year = "1994",
            Rated = "R",
            Released = "14 Oct 1994",
            Runtime = "154 min",
            Genre = "Crime, Drama",
            Director = "Quentin Tarantino",
            Writer = "Quentin Tarantino (stories), Roger Avary (stories), Quentin Tarantino",
            Actors = "Tim Roth, Amanda Plummer, Laura Lovelace, John Travolta",
            Plot = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
            Language = "English, Spanish, French",
            Country = "USA",
            Awards = "Won 1 Oscar. Another 69 wins & 75 nominations.",
            Poster = "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg",

            ImdbRating = "8.9",
            ImdbID = "tt0110912"
        }, new Movie
        {
            Title = "The Good, the Bad and the Ugly",
            Year = "1966",
            Rated = "R",
            Released = "29 Dec 1967",
            Runtime = "178 min",
            Genre = "Western",
            Director = "Sergio Leone",
            Writer = "Luciano Vincenzoni (story), Sergio Leone (story), Agenore Incrocci (screenplay), Furio Scarpelli (screenplay), Luciano Vincenzoni (screenplay), Sergio Leone (screenplay)",
            Actors = "Eli Wallach, Clint Eastwood, Lee Van Cleef, Aldo Giuffrè",
            Plot = "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.",
            Language = "Italian",
            Country = "Italy, Spain, West Germany",
            Awards = "2 wins & 4 nominations.",
            Poster = "https://m.media-amazon.com/images/M/MV5BOTQ5NDI3MTI4MF5BMl5BanBnXkFtZTgwNDQ4ODE5MDE@._V1_SX300.jpg",
            ImdbRating = "8.8",
            ImdbID = "tt0060196"
        },
        new Movie
        {
            Title = "Fight Club",
            Year = "1999",
            Rated = "R",
            Released = "15 Oct 1999",
            Runtime = "139 min",
            Genre = "Drama",
            Director = "David Fincher",
            Writer = "Chuck Palahniuk (novel), Jim Uhls (screenplay)",
            Actors = "Edward Norton, Brad Pitt, Meat Loaf, Zach Grenier",
            Plot = "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.",
            Language = "English",
            Country = "USA, Germany",
            Awards = "Nominated for 1 Oscar. Another 11 wins & 37 nominations.",
            Poster = "https://m.media-amazon.com/images/M/MV5BMmEzNTkxYjQtZTc0MC00YTVjLTg5ZTEtZWMwOWVlYzY0NWIwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg",
            ImdbRating = "8.8",
            ImdbID = "tt0137523"
        },
        new Movie
        {
            Title = "Forrest Gump",
            Year = "1994",
            Rated = "PG-13",
            Released = "06 Jul 1994",
            Runtime = "142 min",
            Genre = "Drama, Romance",
            Director = "Robert Zemeckis",
            Writer = "Winston Groom (novel), Eric Roth (screenplay)",
            Actors = "Tom Hanks, Rebecca Williams, Sally Field, Michael Conner Humphreys",
            Plot = "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate and other historical events unfold through the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.",
            Language = "English",
            Country = "USA",
            Awards = "Won 6 Oscars. Another 44 wins & 75 nominations.",
            Poster = "https://m.media-amazon.com/images/M/MV5BNWIwODRlZTUtY2U3ZS00Yzg1LWJhNzYtMmZiYmEyNmU1NjMzXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SX300.jpg",

            ImdbRating = "8.8",
            ImdbID = "tt0109830"
        },
        new Movie
        {
            Title = "Inception",
            Year = "2010",
            Rated = "PG-13",
            Released = "16 Jul 2010",
            Runtime = "148 min",
            Genre = "Action, Adventure, Sci-Fi, Thriller",
            Director = "Christopher Nolan",
            Writer = "Christopher Nolan",
            Actors = "Leonardo DiCaprio, Joseph Gordon-Levitt, Ellen Page, Tom Hardy",
            Plot = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
            Language = "English, Japanese, French",
            Country = "USA, UK",
            Awards = "Won 4 Oscars. Another 152 wins & 218 nominations.",
            Poster = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SX300.jpg",

            ImdbRating = "8.8",
            ImdbID = "tt1375666"
        },
        new Movie
        {
            Title = "The Matrix",
            Year = "1999",
            Rated = "R",
            Released = "31 Mar 1999",
            Runtime = "136 min",
            Genre = "Action, Sci-Fi",
            Director = "Lana Wachowski, Lilly Wachowski",
            Writer = "Lilly Wachowski, Lana Wachowski",
            Actors = "Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving",
            Plot = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
            Language = "English",
            Country = "USA",
            Awards = "Won 4 Oscars. Another 37 wins & 51 nominations.",
            Poster = "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg",
            ImdbRating = "8.7",
            ImdbID = "tt0133093"
        });
            context.SaveChanges();
        }
    }
}
