using System;
using System.Collections.Generic;
using ConsoleUI;

namespace GraphicsEditor.Commands
{
    class RemoveCommand : ICommand
    {
        private readonly Picture picture;

        public string Name => "remove";
        public string Help => "Удалить фигуры";
        public string Description => "";
        public string[] Synonyms => new[] {"rem"};

        public RemoveCommand(Picture picture)
        {
            this.picture = picture;
        }

        public void Execute(params string[] parameters)
        {
            var errors = ParseArguments(parameters, out var parsed);
            if (errors.Count != 0)
            {
                Console.WriteLine($"Обнаружены ошибки ввода: {string.Join(", ", errors)}");
                return;
            }
            var shapes = picture.GetShapes();
            parsed.Sort();
            parsed.Reverse();
            foreach (var index in parsed)
            {
                if (index >= shapes.Length || index < 0)
                {
                    Console.WriteLine($"Не существует элемента под номером: {index}");
                    continue;
                }
                Console.WriteLine($"Удаляем элемент: {shapes[index]}");
                picture.RemoveAt(index);
            }
        }

        protected static List<string> ParseArguments(string[] args, out List<int> result)
        {
            var errors = new List<string>();
            result = new List<int>();
            foreach (var argument in args)
            {
                try
                {
                    var parsed = int.Parse(argument);
                    result.Add(parsed);
                }
                catch (Exception e) when (e is OverflowException || e is FormatException)
                {
                    errors.Add(argument);
                }
            }
            return errors;
        }
    }
}