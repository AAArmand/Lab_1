using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Commands {
    /// <summary>
    /// Реализует вывод всех возмодных 
    /// команд и их описание в консоль 
    /// </summary>
    public class HelpCommand : ICommand {
        public string Name { get { return "help"; } }
        public string[] Synonyms {
            get { return new string[] { "helping", "support" }; }
        }
        public string Description {
            get { return " - выводит описание программы и возможные команды\n"; }
        }

        public void Execute(params string[] inputParametrs) {
            try {
                if ((inputParametrs[0].ToString() != "") && (inputParametrs[0].ToString() != " ")) {
                    throw new ArgumentException("Команда не принимает параметров");
                }

                CommandsInit commandsInit = new CommandsInit();
                foreach (ICommand option in commandsInit.Options) {
                    Console.WriteLine(option.Name + option.Description);
                }

            } catch (ArgumentException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}

