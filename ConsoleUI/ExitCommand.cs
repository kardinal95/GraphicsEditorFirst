using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class ExitCommand : ICommand
    {
        Application app;
        public ExitCommand(Application app)
        {
            this.app = app;
        }
        public string Name { get { return "exit"; } }
        public string Help { get { return "Выход из программы"; } }
        public string[] Synonyms
        {
            get { return new string[] { "quit", "bye" }; }
        }
        public string Description
        {
            get { return "Длинное и подробное описание команды выхода "; }
        }
        public void Execute(params string[] parameters)
        {
            app.Exit();
        }
    }
}
