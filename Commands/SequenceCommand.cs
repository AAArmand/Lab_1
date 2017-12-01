using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Commands {
    /// <summary>
    /// Реализует установку сортируемой последовательности
    /// целых чисел
    /// </summary>
    class SequenceCommand : ICommand {
        public string Name { get { return "sequence"; } }
        public string Description {
            get {
                return " - устанавливает последовательность для тестирования,\n" +
                    "принимает в качестве параметров целые числа через пробел\n";
            }
        }
        public string[] Synonyms { get { return new string[] { "array", "numbers" }; } }

        /// <summary>
        /// Извлекает из входной строки
        /// массив целых чисел
        /// </summary>
        /// <param name="str">
        /// Строка, состояющая из чисел,
        /// записанных через пробел
        /// </param>
        /// <returns>
        /// Массив целых чисел
        /// </returns>
        int[] GetNumbers(string str) {

            if (str == "") {
                throw new Exception("Введите последовательность для сортировки");
            }

            string[] parametrs = str.Split(
                new char[] { ' ', '\t' },
                StringSplitOptions.RemoveEmptyEntries);
            List<int> numbers = new List<int>();

            int numValue;
            foreach (string parametr in parametrs) {
                
                try {
                    numValue = Int32.Parse(parametr);
                    numbers.Add(numValue);
                } catch (FormatException) {
                    Console.WriteLine("Неверный формат параметра {0}", parametr);
                } catch (OverflowException) {
                    Console.WriteLine("Параметр {0} слишком большой", parametr);
                }
            }
            
            if (numbers.Count == parametrs.Length) {
                int[] integerParametrs = numbers.ToArray();
                return integerParametrs;
            } else {
                return null;
            }    
        }

        /// <summary>
        /// Заполняет элемент с ключом sequence
        /// значением входной строки параметров
        /// соответствующих требованиям команды
        /// </summary>
        /// <param name="inputParametrs"></param>
        /// <param name="param">словарь для доступа к итерациям и последовательности</param>
        public void Execute(params string[] inputParametrs) {

            try {
                if (inputParametrs == null) {
                    throw new Exception("Команда должна принимать последовательность целых чисел");
                }

                TestCommand.sequence = GetNumbers(inputParametrs[0]);
            } catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }
    }
}
