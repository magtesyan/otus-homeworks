using System.Diagnostics;

static int getIterativeFibonacci(int n)
{
    int prev = 0;
    int beforePrev = 0;
    for (int i = 1; i != n + 1; i++)
    {
        if (i == 1) prev = 1;
        else {
            int tmp = prev;
            prev += beforePrev;
            beforePrev = tmp;
        }
    }
    return prev;
}

static int getRecursiveFibonacci(int n)
{
    if (n == 0 || n == 1) return n;

    int i = 1;
    int result = 0;
    while (i != n)
    {
        result = getRecursiveFibonacci(i) + getRecursiveFibonacci(i - 1);
        i++;
    }

    return result;
}

static void measureTime(int n)
{
    Stopwatch stopwatch = new();
    Console.WriteLine($"Значение: {n}");
    stopwatch.Start();
    getIterativeFibonacci(n);
    stopwatch.Stop();
    Console.WriteLine($"Время выполнения итеративной функции: {stopwatch.Elapsed.TotalMilliseconds} мс");

    stopwatch.Start();
    getRecursiveFibonacci(n);
    stopwatch.Stop();
    Console.WriteLine($"Время выполнения рекурсивной функции: {stopwatch.Elapsed.TotalMilliseconds} мс\n");
}

measureTime(5);
