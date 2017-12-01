using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands {
    class ExitCommand : ICommand {
        public string Name { get { return "exit"; } }
        public string[] Synonyms {
            get { return new string[] { "quit", "bye" }; }
        }
        public string Description {
            get { return " - позволяет выйти из консоли и завершить работу программы\n"; }
        }
        public void Execute(params string[] inputParametrs) {
            try {
                if (inputParametrs.Length > 0) {
                    throw new ArgumentException("exit не принимает параметров");
                }

                Console.WriteLine("Очень жаль, что уходите :(");
                Environment.Exit(0);
            } catch (ArgumentException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
