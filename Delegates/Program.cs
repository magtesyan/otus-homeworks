namespace Delegates
{
    internal class Program
    {
        private static readonly PlanetList Planets = new();
        private static int TryCount;

        static void Main()
        {
            static void PrintFoundPlanet(string name)
            {
                TryCount++;
                (int index, long equator, string error) = Planets.GetPlanet(name, (string name) =>
                {
                    if (TryCount == 3)
                    {
                        TryCount = 0;
                        return "Вы спрашиваете слишком часто";
                    }

                    if (name == "Лимония")
                        return "Это запретная планета";

                    return "";
                });

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
            PrintFoundPlanet("Земля");
            PrintFoundPlanet("Не Земля");
        }
    }
}
