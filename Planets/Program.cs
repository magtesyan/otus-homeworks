namespace Planets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Venus = new
            {
                name = "Венера",
                index = 2,
                equator = 38052,
                prevPlanet = null as object
            };

            var Earth = new
            {
                name = "Земля",
                index = 3,
                equator = 40075696,
                prevPlanet = Venus
            };

            var Mars = new
            {
                name = "Марс",
                index = 4,
                equator = 21344,
                prevPlanet = Earth
            };

            var Venus2 = new
            {
                name = "Венера",
                index = 2,
                equator = 38052,
                prevPlanet = null as object
            };

            void PrintPlanetInfo(dynamic planet)
            {
                bool IsVenus = planet.Equals(Venus);
                string IsVenusInfo = IsVenus ? "Кстати это Венера\n" : string.Empty;
                string prevPlanetInfo = planet.prevPlanet?.name != null ? $"Предыдущая планета: {planet.prevPlanet.name}\n" : string.Empty;

                Console.WriteLine($"Название планеты: {planet.name}\n" +
                    $"Порядковый номер от солнца: {planet.index}\n" +
                    $"Длина экватора: {planet.equator}\n" +
                    prevPlanetInfo + IsVenusInfo
                    );

            }

            PrintPlanetInfo(Venus);
            PrintPlanetInfo(Earth);
            PrintPlanetInfo(Mars);
            PrintPlanetInfo(Venus2);
        }
    }
}
