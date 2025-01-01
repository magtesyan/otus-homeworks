using System.Numerics;

namespace Tuples
{
    internal class Program
    {
        private static readonly PlanetList Planets = new();
        static void Main()
        {
            static void PrintFoundPlanet(string name)
            {
                (int index, long equator, string error) = Planets.GetPlanet(name);
                if (!string.IsNullOrEmpty(error))
                {
                    Console.WriteLine($"{error}\n");
                    return;
                }

                Console.WriteLine($"Название планеты: {name}\n" +
                    $"Порядковый номер от солнца: {index}\n" +
                    $"Длина экватора: {equator}\n");
            }

            PrintFoundPlanet("Земля");
            PrintFoundPlanet("Лимония");
            PrintFoundPlanet("Марс");
        }
    }
}
