using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class HelpCommand : ICommand
    {
        Application app;
        public string Name { get { return "help"; } }
        public string Help { get { return "Краткая помощь по всем командам"; } }
        public string[] Synonyms
        {
            get { return new string[] { "?" }; }
        }
        public string Description
        {
            get { return "Выводит список  команд с краткой помощью"; }
        }

        public HelpCommand(Application app)
        {
            this.app = app;
        }
        public void Execute(params string[] parameters)
        {
            Console.WriteLine(line);
            foreach (ICommand cmd in app.Commands)
            {
                Console.WriteLine("{0}: {1}", cmd.Name, cmd.Help);
            }
            Console.WriteLine(line);
        }

        private const string line = "================================================";

    }

}
