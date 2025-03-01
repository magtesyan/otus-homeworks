using System.Collections.Immutable;

namespace Jack
{
    public interface IPart
    {
        ImmutableList<string> Poem { get; set; }
        ImmutableList<string> AddPart(ImmutableList<string> poemStrokes);
    }
}
