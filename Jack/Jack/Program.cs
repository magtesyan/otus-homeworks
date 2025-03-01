using Jack;
using System.Collections.Immutable;

ImmutableList<string> PoemStrokes = [];
IPart Part1 = new Part1();
IPart Part2 = new Part2();
IPart Part3 = new Part3();
IPart Part4 = new Part4();
IPart Part5 = new Part5();
IPart Part6 = new Part6();
IPart Part7 = new Part7();
IPart Part8 = new Part8();
IPart Part9 = new Part9();

(Part9.AddPart(Part8.AddPart(Part7.AddPart(Part6.AddPart(Part5.AddPart(Part4.AddPart(Part3.AddPart(Part2.AddPart(Part1.AddPart(PoemStrokes)))))))))).ForEach((stroke) => Console.WriteLine(stroke));

Console.WriteLine("\nPart 3");
Part3.Poem.ForEach((stroke) => Console.WriteLine(stroke));
