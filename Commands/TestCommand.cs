using System;
using System.Collections.Generic;
using CommandsData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Commands {
    /// <summary>
    /// Реализует измерение времени работы
    /// различных алгоритмов сортировки 
    /// массива из <see cref="Sorting"/>
    /// </summary>
    class TestCommand : ICommand {

        public static int[] sequence;
        public static int iterations;

        public string Name { get { return "test"; } }

        public string Description {
            get {
                return " - запускает работу алгоритмов.\n" +
                    "Каждый алгоритм выполняется на последовательности sequence, iterations раз.\n" +
                    "В результате выводится среднее время работы каждого алгоритма.\n";
            }
        }
        public string[] Synonyms { get { return new string[] { "start", "go" }; } }



        /// <summary>
        /// Увеличивает размер массива на 1
        /// и присваевает последнему элементу 
        /// входной объект
        /// </summary>
        /// <param name="inputParams">массив объектов</param>
        /// <param name="newParam">новый объект</param>
        void RefreshArray(ref object[] inputParams, object newParam) {
            Array.Resize(ref inputParams, inputParams.Length + 1);
            inputParams[inputParams.Length - 1] = newParam;
        }

        /// <summary>
        /// Вычисляет среднее время работы
        /// стандартного метода сортировки
        /// </summary>
        /// <param name="currentArray">сортируемый массив</param>
        /// <param name="iterations">количество выполнений сортировки</param>
        /// <param name="param">словарь для доступа к входной последовательности чисел</param>
        void StandartSortTime(int[] currentArray, int iterations, int[] sequence) {
            double time = 0;
            Stopwatch stopwatch = new Stopwatch();
            for (int i = iterations; i > 0; i--) {
                stopwatch.Start();
                Array.Sort(currentArray);
                stopwatch.Stop();
                time += stopwatch.Elapsed.TotalMilliseconds;
                stopwatch.Reset();
                currentArray = sequence;
            }
            time /= iterations;
            Console.WriteLine(".NET Sort: {0:0.####} мс", time);
            time = 0;
        }

        /// <summary>
        /// Выводит время работы всех необходимых алгоритмов сортировки,
        /// размер массива и количество итераций
        /// </summary>
        /// <param name="inputParametrs"></param>
        /// <param name="param">словарь для доступа к итерациям и последовательности</param>
        public void Execute(params string[] inputParametrs) {
            try {
                if ((inputParametrs[0].ToString() != "") && (inputParametrs[0].ToString() != " ")) {
                    throw new Exception("Команда не принимает параметров");
                }

                if (TestCommand.sequence == null) {
                    throw new Exception("Не задана последовательность для тестирования");
                }

                Sorting sorting = new Sorting();
                Type type = typeof(Sorting);
                MethodInfo[] sorts = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                    .Where(t => t.Name.Contains("Sort"))
                    .ToArray();

                Stopwatch stopWatch = new Stopwatch();
                double time;

                int[] currentArray = TestCommand.sequence;

                Console.Write("Количество итераций: " + TestCommand.iterations + " ");
                Console.WriteLine("Размер массива: " + currentArray.Length);

                foreach (MethodInfo sort in sorts) {
                    time = 0;
                    object[] inputParams = { };

                    foreach (ParameterInfo parameter in sort.GetParameters()) {
                        if (parameter.Name == "array") {
                            RefreshArray(ref inputParams, currentArray);
                        }
                        if (parameter.Name == "start") {
                            RefreshArray(ref inputParams, 0);
                        }
                        if (parameter.Name == "end") {
                            RefreshArray(ref inputParams, currentArray.Length - 1);
                        }
                    }

                    for (int i = TestCommand.iterations; i > 0; i--) {
                        stopWatch.Start();
                        sort.Invoke(sorting, inputParams);
                        stopWatch.Stop();
                        time += stopWatch.Elapsed.TotalMilliseconds;
                        stopWatch.Reset();
                    }

                    time /= TestCommand.iterations;
                    Console.WriteLine(sort.Name + ": {0:0.####} мс", time);

                }

                StandartSortTime(currentArray, TestCommand.iterations, TestCommand.sequence);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
