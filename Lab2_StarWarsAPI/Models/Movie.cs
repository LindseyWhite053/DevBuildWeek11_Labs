namespace Lab2_StarWarsAPI.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public int Episode { get; set; }
        public int Year { get; set; }
        public List<Character> Characters { get; set; }
        public List<Starship> ShipNames { get; set; }

        public Movie()
        {
            Characters = new List<Character>();
            ShipNames = new List<Starship>();
        }
    }

    public class Character
    {
        public string CharName { get; set; }

    }

    public class Starship
    {
        public string ShipName { get; set; }
        public string ShipModel { get; set; }
        public string Cost { get; set; }
    }
}
