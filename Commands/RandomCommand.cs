using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands {
    /// <summary>
    /// Реализует генерацию 
    /// случайной последовательности
    /// </summary>
    class RandomCommand : ICommand {

        public string Name { get { return "random"; } }
        public string Description {
            get {
                return " - генерирует случайный массив целых чисел для тестирования\n" +
                    "Необязательный параметр для этой команды\n" +
                    "— длина массива. По умолчанию он равен 1000.\n";
            }
        }
        public string[] Synonyms { get { return new string[] { "rand", "chance" }; } }

        /// <summary>
        /// Генерирует случайную последовательность целых чисел
        /// в строковом представлении
        /// </summary>
        /// <param name="inputParametrs"></param>
        /// <param name="param">словарь для доступа к итерациям и последовательности</param>
        public void Execute(params string[] inputParametrs) {

            
            try {
                if (inputParametrs[0].IndexOf(' ') != -1) {
                throw new Exception("Команда принимает только один необязательный параметр");
                }

                int size;

                if (inputParametrs[0] == "") {
                    size = 1000;
                } else {
                    size = int.Parse(inputParametrs[0]);
                }
                
                int[] array = new int[size];
                Random rand = new Random();
                for (int i = 0; i < array.Length; i++) {
                    array[i] = rand.Next();
                }

                TestCommand.sequence = array;
            } catch (FormatException) {
                Console.WriteLine("Недопустимый формат параметра, необходимо целое число");
            } catch (OverflowException) {
                Console.WriteLine("Введен слишком большой размер массива");
            }

            
        }
    }
}
