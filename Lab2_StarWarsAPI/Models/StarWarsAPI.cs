namespace Lab2_StarWarsAPI.Models
{
    
    public class Film
    {
        public string title { get; set; }
        public DateTime release_date { get; set; }
        public int episode_id { get; set; }
        public List<string> characters { get; set; }
        public List<string> starships { get; set; }

    }

    public class APICharacter
    {
        public string name { get; set; }

    }

    public class APIStarship
    {
        public string name { get; set; }
        public string model { get; set; }
        public string cost_in_credits { get; set; }
    }
    
    
    public class StarWarsAPI
    {
        //API Documentation https://swapi.dev/documentation

        public static HttpClient _web = null;

        public static HttpClient GetHttpClient()
        {
            if (_web == null)
            {
                _web = new HttpClient();
                _web.BaseAddress = new Uri("https://swapi.dev/api/");
            }

            return _web;
        }

        public async static Task<Movie> GetMovie(int filmnumber)
        {
            HttpClient web = GetHttpClient();
            var connection = await web.GetAsync($"films/{filmnumber}/");
            Film resp = await connection.Content.ReadAsAsync<Film>();

            Movie newMovie = new Movie();
            newMovie.Title = resp.title;
            newMovie.Year = resp.release_date.Year;
            newMovie.Episode = resp.episode_id;


            foreach (string c in resp.characters)
            {
                connection = await web.GetAsync(c);
                APICharacter character = await connection.Content.ReadAsAsync<APICharacter>();
                Character ch = new Character();
                ch.CharName = character.name;
                newMovie.Characters.Add(ch);
            }


            foreach (string s in resp.starships)
            {
                connection = await web.GetAsync(s);
                APIStarship starship = await connection.Content.ReadAsAsync<APIStarship>();
                Starship shp = new Starship();
                shp.ShipName = starship.name;
                shp.ShipModel = starship.model;
                shp.Cost = starship.cost_in_credits;
                newMovie.ShipNames.Add(shp);
            }

            return newMovie;
        }

    }

}
