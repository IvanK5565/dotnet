using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    private static double sum = 0;
    private static object lockObject = new object();

    static void ComputePartialSum(int start, int end)
    {
        double localSum = 0;
        for (int i = start; i <= end; i++)
        {
            localSum += (double)i / (1 + i * Math.Pow(4, i));
        }

        lock (lockObject)
        {
            sum += localSum;
        }
    }

    static void Main()
    {
        int n = 10000; // Количество членов ряда
        int[] threadCounts = { 1, 3, 5, 7, 9, 11 }; // Количество потоков для тестирования

        foreach (int threadCount in threadCounts)
        {
            sum = 0; // Сбрасываем сумму перед каждым запуском
            Thread[] threads = new Thread[threadCount];
            int chunkSize = n / threadCount;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int t = 0; t < threadCount; t++)
            {
                int start = t * chunkSize;
                int end = (t == threadCount - 1) ? n : (start + chunkSize - 1);
                threads[t] = new Thread(() => ComputePartialSum(start, end));
                threads[t].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
            stopwatch.Stop();

            Console.WriteLine($"Потоки: {threadCount}, Время: {stopwatch.ElapsedMilliseconds} мс, Сумма: {sum}");
        }
    }
}
