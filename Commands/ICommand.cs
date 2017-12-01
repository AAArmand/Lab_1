using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Commands {
    /// <summary>
    /// Устанавливает базовую архитектуру
    /// классам команд
    /// </summary>
    public interface ICommand {
        string Name { get; }

        string Description { get; }

        string[] Synonyms { get; }

        void Execute(params string[] inputParametrs);
    }
}
