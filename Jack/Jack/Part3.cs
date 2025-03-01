using System.Collections.Immutable;

namespace Jack
{
    class Part3 : IPart
    {
        public ImmutableList<string> Poem { get; set; } = ImmutableList<string>.Empty;
        public ImmutableList<string> AddPart(ImmutableList<string> poemStrokes)
        {
            Poem = poemStrokes.Add("\nА это веселая птица-синица,\r\nКоторая часто ворует пшеницу,\r\nКоторая в темном чулане хранится\r\nВ доме,\r\nКоторый построил Джек.");
            return Poem;
        }
    }
}
