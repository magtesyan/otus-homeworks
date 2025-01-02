namespace Delegates
{
    public class Planet(string name, int index, long equator, Planet? prevPlanet)
    {
        public string Name { get; set; } = name;
        public int Index { get; set; } = index;
        public long Equator { get; set; } = equator;
        public Planet? PrevPlanet { get; set; } = prevPlanet;
}
}
