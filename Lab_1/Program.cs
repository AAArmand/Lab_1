using System;
using System.Reflection;
using System.Linq;
using Commands;
using CommandsData;
using System.Text;

namespace Lab_1 { 
    class Program {
        
        static void Main(string[] args) {
            Console.OutputEncoding = Encoding.UTF8;
            Application app = new Application();
            if (args.Length == 0) {
                while (true) {
                    app.RunCommand();
                }
            }
            else {
                app.RunFile(args[0]);
            }
        }
    }
}

