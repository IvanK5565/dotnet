using System;
using System.Diagnostics;
using System.Threading;
namespace ConsoleThread
{
    // Клас передачі параметрів в потік
    class SeriesParams
    {
        public int begin, end;
        public SeriesParams(int b, int e)
        {
            begin = b;
            end = e;
        }
    }
    class Program
    {
        public static Mutex mutex = new Mutex(); // Створення мьютексу
        public static int NumThread = 8; // Кількість потоків
        public static double Sum = 0; // Підсумкова сума
        public static int[] tests = {1,3,5,7,9,11};
        static void Main(string[] args)
        {
            for (int test = 0; test < tests.Length; test++)
            {
                Sum = 0;
                NumThread = tests[test];
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Thread[] thr = new Thread[NumThread];
                var MaxIter = 10000000; // Загальна кількість ітерацій
                var step = MaxIter / NumThread; // Кількість ітерацій у потоці
                for (int i = 0; i < NumThread; i++) // Запуск потоків
                {
                    thr[i] = new Thread(new ParameterizedThreadStart(CalcSeries)); // Створення i-го потоку
                                                                                   // Запуск потоку та передача в нього параметрів
                    thr[i].Start(new SeriesParams(i * step, (i == NumThread - 1) ? MaxIter : (i + 1) * step));
                }
                for (int i = 0; i < NumThread; i++) // Очікування завершення потоків
                    thr[i].Join();
                stopwatch.Stop();
                Console.WriteLine("Num of threads: {0}, Sum of series: {1} in {2} milliseconds", NumThread, Sum, stopwatch.ElapsedMilliseconds);
            }
                Console.ReadKey();
        }
        // Обчислення суми ряду для заданого діапазону ітерацій
        public static void CalcSeries(object param)
        {
            double sum = 0;
            if (param is SeriesParams)
            {
                for (double i = ((SeriesParams)param).begin; i < ((SeriesParams)param).end; i++)
                    sum += (1.0 / (1 + i * i * i));
                mutex.WaitOne(); // Закрити м'ютекс
                Sum += sum; // Змінити ресурс, за який може виникнути гонка
                mutex.ReleaseMutex(); // Звільнити м'ютекс
            }
        }
    }
}