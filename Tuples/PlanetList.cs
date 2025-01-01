namespace Tuples
{
    public class PlanetList
    {
        private readonly List<Planet> Planets = [];
        private static int TryCount;

        public PlanetList()
        {
            Planet Venus = new("Венера", 2, 38052, null);
            Planet Earth = new("Земля", 3, 40075696, Venus);
            Planet Mars = new("Марс", 4, 21344, Earth);
            Planets.AddRange([Venus, Earth, Mars]);
        }

        public (int, long, string) GetPlanet(string name)
        {
            Planet? foundPlanet = Planets.Find((planet) => planet.Name == name);
            TryCount++;

            if (foundPlanet == null) return (0, 0, "Не удалось найти планету");
            if (TryCount == 3)
            {
                TryCount = 0;
                return (0, 0, "Вы спрашиваете слишком часто");
            }
            return (foundPlanet.Index, foundPlanet.Equator, "");
    }
}}
