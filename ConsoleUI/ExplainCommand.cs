using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class ExplainCommand : ICommand
    {
        Application app;

        public string Name { get { return "explain"; } }
        public string Help { get { return "Рассказать о команде или командах"; } }
        public string[] Synonyms
        {
            get { return new string[] { "elaborate" }; }
        }
        public string Description
        {
            get { return "Выводит всю доступную информацию по команде или командам. Имена команд передаются как параметры"; }
        }

        public ExplainCommand(Application app)
        {
            this.app = app;
        }
        public void Execute(params string[] parameters)
        {
            foreach (var parameter in parameters)
            {
                ICommand cmd = app.FindCommand(parameter);
                Console.WriteLine(line);
                List<string> syns = new List<string>(cmd.Synonyms);
                if (cmd.Name == parameter)
                {
                    Console.WriteLine("{0}: {1}", cmd.Name, cmd.Help);
                }
                else
                {
                    Console.WriteLine("{0}: {1}", parameter, cmd.Help);
                    syns.Remove(parameter);
                    syns.Add(cmd.Name);
                }
                if (syns.Count > 0)
                {
                    Console.WriteLine("Синонимы: {0}", string.Join(", ", syns));
                }
                if (cmd.Description != string.Empty)
                {
                    Console.WriteLine(line1);
                    Console.WriteLine(cmd.Description);
                }
            }
            Console.WriteLine(line);
        }

        private const string line = "================================================";
        private const string line1 = "...............................................";

    }

}
