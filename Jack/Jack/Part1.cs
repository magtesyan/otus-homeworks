using System.Collections.Immutable;

namespace Jack
{
    class Part1 : IPart
    {
        public ImmutableList<string> Poem { get; set; } = ImmutableList<string>.Empty;
        public ImmutableList<string> AddPart(ImmutableList<string> poemStrokes)
        {
            Poem = poemStrokes.Add("\nВот дом,\r\nКоторый построил Джек.");
            return Poem;
        }
    }
}
