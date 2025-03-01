using System.Collections.Immutable;

namespace Jack
{
    class Part6 : IPart 
    {
        public ImmutableList<string> Poem { get; set; } = ImmutableList<string>.Empty;
        public ImmutableList<string> AddPart(ImmutableList<string> poemStrokes)
        {
            Poem = poemStrokes.Add("\nА это корова безрогая,\r\nЛягнувшая старого пса без хвоста,\r\nКоторый за шиворот треплет кота,\r\nКоторый пугает и ловит синицу,\r\nКоторая часто ворует пшеницу,\r\nКоторая в темном чулане хранится\r\nВ доме,\r\nКоторый построил Джек.");
            return Poem;
        }
    }
}
