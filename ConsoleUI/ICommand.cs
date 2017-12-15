using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    /// <summary>
    /// Команда которую пользователь может выполнить,
    /// введя имя команды в консоли
    /// </summary>
    public interface ICommand
    {
        string Name { get; }
        string Help { get; }
        string Description { get; }
        string[] Synonyms { get; }
        void Execute(params string[] parameters);
    }
}
