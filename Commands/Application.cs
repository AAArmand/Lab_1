using System;
using System.IO;
using System.Linq;

namespace Commands {
    /// <summary>
    /// Реализует сборку всех данных 
    /// и начало работы приложения
    /// </summary>
    public class Application {
        CommandsInit commandsInit;
        const string POINTER = " >>> ";
        
        public Application() {
            commandsInit = new CommandsInit();
            TestCommand.iterations = 100;
            TestCommand.sequence = null;

        }

        public ICommand FindCommand(string commandName) {
            ICommand returnObject = null;
            commandsInit.Options.ForEach(obj => {
                if (obj.Name == commandName || obj.Synonyms.Contains(commandName)) {
                    returnObject = obj;
                }
            });
            return returnObject;
        }

        public void RunCommand(string key = null) {

            if (key == null) {
                Console.Write(POINTER);
                key = Console.ReadLine();
            }

            string option = key.Split(
                new char[] { ' ', '\t' },
                StringSplitOptions.RemoveEmptyEntries)[0];
            string inputParametrs = key.Substring(option.Length).Trim(); ;

            ICommand command = FindCommand(option);
            try {
                command.Execute(inputParametrs);
            } catch (NullReferenceException) {
                Console.WriteLine("Вы ввели неверную команду, пожалуйста, повторите ввод");
            }
        }

        public void RunFile(string file) {
            using (StreamReader key = new StreamReader(file, System.Text.Encoding.Default)) {
                string command;
                while ((command = key.ReadLine()) != null) {
                    RunCommand(command);
                }
            }
        }
    }
}

