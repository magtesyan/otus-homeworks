namespace Delegates
{
    public class PlanetList
    {
        private readonly List<Planet> Planets = [];

        public delegate string PlanetValidator(string name);

        public PlanetList()
        {
            Planet Venus = new("Венера", 2, 38052, null);
            Planet Earth = new("Земля", 3, 40075696, Venus);
            Planet Mars = new("Марс", 4, 21344, Earth);
            Planets.AddRange([Venus, Earth, Mars]);
        }

        public (int, long, string) GetPlanet(string name, PlanetValidator validator)
        {
            string validationError = validator(name);
            if (!string.IsNullOrEmpty(validationError)) return (0, 0, validationError);

            {
                
            }
            Planet? foundPlanet = Planets.Find((planet) => planet.Name == name);

            if (foundPlanet == null) return (0, 0, "Не удалось найти планету");
            return (foundPlanet.Index, foundPlanet.Equator, "");
    }
}}
