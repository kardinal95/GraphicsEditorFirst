using System;
using System.Drawing;
using System.Linq;
using ConsoleUI;

namespace GraphicsEditor.Commands
{
    class ColorCommand : ICommand
    {
        private readonly Picture picture;

        public string Name => "color";
        public string Help => "Окрасить фигуры в требуемый цвет";

        public string Description => "Окрашивает указанные фигуры в требуемый цвет\n" +
                                     "Использование: \'color clr x y ..\', где x, y, .. - индексы фигур в команде list, clr - существующий цвет";

        public string[] Synonyms => new[] { };

        public ColorCommand(Picture picture)
        {
            this.picture = picture;
        }

        public void Execute(params string[] parameters)
        {
            // Проверяем количество параметров
            if (parameters.Length <= 1)
            {
                Console.WriteLine("Недостаточное количество аргументов");
                return;
            }
            // Проверяем правильность цвета
            var color = Color.FromName(parameters[0]);
            if (!color.IsKnownColor)
            {
                Console.WriteLine("Указан неизвестный цвет!");
                return;
            }
            // Проверяем ошибки во вводе индексов
            var cut = parameters.Skip(1).ToArray();
            var errors = CommandLib.ParseArguments<int>(cut, out var parsed);
            if (errors.Count != 0)
            {
                Console.WriteLine($"Обнаружены ошибки ввода: {string.Join(", ", errors)}");
                return;
            }
            // Проверяем существование индексов
            var missing = CommandLib.CheckShapeIndexes(parsed, picture, out var indexes);
            if (missing.Count != 0)
            {
                Console.WriteLine($"Отсутствуют фигуры с индексами: {string.Join(", ", missing)}");
            }
            // Выполняем действия
            if (indexes.Count == 0)
            {
                return;
            }
            Console.WriteLine($"Окрашиваем фигуры с индексами: {string.Join(", ", indexes)}");
            foreach (var index in indexes)
            {
                picture.RecolorAt(index, color);
            }
        }
    }
}