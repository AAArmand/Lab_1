using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands {
    /// <summary>
    /// Реализует инициализацию количества
    /// повторений алгоритмов сортировки
    /// </summary>
    class IterationsCommand : ICommand{
        public string Name { get { return "iterations"; } }
        public string Description { get { return "- устанавливает количество повторений алгоритмов " +
                    "для вычисления среднего времени работы.\n" +
                    "Параметр для этой команды - количество итераций.\n" +
                    "Значение по умолчанию: 100\n"; } }
        public string[] Synonyms { get { return new string[] { "repeat", "reiterative" }; } }

        /// <summary>
        /// Задает количество итераций, 
        /// необходимых для вычисления среднего времени
        /// работы алгоритмов
        /// </summary>
        /// <param name="inputParametrs"></param>
        /// <param name="param">словарь для доступа к итерациям и последовательности</param>
        public void Execute(params string[] inputParametrs) {
            try {
                if (inputParametrs[0].IndexOf(' ') != -1) {
                throw new Exception("Команда принимает только один параметр");
                }

                int parametr;
                if (inputParametrs[0] != "") {
                    parametr = int.Parse(inputParametrs[0]);
                    
                    if (parametr <= 0) {
                        throw new Exception("Количество итераций должно быть больше 0");
                    }

                    TestCommand.iterations = parametr;
                }

             } catch (FormatException) {
                Console.WriteLine("Недопустимый формат параметра");
             } catch (OverflowException) {
                Console.WriteLine("Введено слишком большое число итераций");
             } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
             
        }
    }
}
