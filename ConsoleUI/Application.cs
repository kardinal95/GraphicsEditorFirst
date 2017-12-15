using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleUI
{
    public class Application
    {
        NotFoundCommand notFound = new NotFoundCommand();
        bool keepRunning = true;
        List<ICommand> commands = new List<ICommand>();
        Dictionary<string, ICommand> commandMap = new Dictionary<string, ICommand>();

        public void Exit()
        {
            keepRunning = false;
        }

        public ICommand FindCommand(string name)
        {
            if (commandMap.ContainsKey(name))
            {
                return commandMap[name];
            }
            notFound.Name = name;
            return notFound;
        }

        public IList<ICommand> Commands { get { return commands; } }
        public void AddCommand(ICommand cmd)
        {
            commands.Add(cmd);
            if (commandMap.ContainsKey(cmd.Name))
            {
                throw new Exception(String.Format("Команда {0} уже добавлена", cmd.Name));
            }
            commandMap.Add(cmd.Name, cmd);
            foreach (var s in cmd.Synonyms)
            {
                if (commandMap.ContainsKey(s))
                {
                    Console.WriteLine("ERROR: Игнорирую синоним {0} для команды {1}, поскольку имя {0}  уже использовано", s, cmd.Name);
                    continue;
                }
                commandMap.Add(s, cmd);
            }
        }
        public void Run(TextReader reader)
        {
            string[] cmdline, parameters;
            while (keepRunning)
            {
                Console.Write("> ");
                var cmd = reader.ReadLine();
                if (cmd == null) 
                {
                    break;
                }
                cmdline = cmd.Split(
                    new char[] { ' ', '\t' },
                    StringSplitOptions.RemoveEmptyEntries
                );
                if (cmdline.Length == 0)
                {
                    continue;
                }

                parameters = new string[cmdline.Length - 1];
                Array.Copy(cmdline, 1, parameters, 0, cmdline.Length - 1);
                FindCommand(cmdline[0]).Execute(parameters);
            }
        }
    }
}
