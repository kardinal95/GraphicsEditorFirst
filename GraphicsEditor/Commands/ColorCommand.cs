using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ConsoleUI;
using DrawablesUI;
using GraphicsEditor.Shapes;

namespace GraphicsEditor.Commands
{
    class ColorCommand : ICommand
    {
        private readonly Picture picture;

        public string Name => "color";
        public string Help => "Сохранить текущее изображение";
        public string Description => "";
        public string[] Synonyms => new[] { "sv" };

        public ColorCommand(Picture picture)
        {
            this.picture = picture;
        }

        public void Execute(params string[] parameters)
        {
            if (parameters.Length <= 1)
            {
                Console.WriteLine("Недостаточное количество аргументов");
                return;
            }
            var color = Color.FromName(parameters[0]);
            if (!color.IsKnownColor)
            {
                Console.WriteLine("Указан неизвестный цвет!");
                return;
            }
            var errors = ParseArguments(parameters.Skip(1).ToArray(), out var parsed);
            if (errors.Count != 0)
            {
                Console.WriteLine($"Обнаружены ошибки ввода: {string.Join(", ", errors)}");
                return;
            }
            var shapes = picture.GetShapes();
            foreach (var index in parsed)
            {
                if (index >= shapes.Length || index < 0)
                {
                    Console.WriteLine($"Не существует элемента под номером: {index}");
                    continue;
                }
                Console.WriteLine($"Окрашиваем элемент: {shapes[index]}");
                picture.Recolor(index, color);
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
