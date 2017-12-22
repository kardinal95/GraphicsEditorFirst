using System;
using System.Linq;
using ConsoleUI;

namespace GraphicsEditor.Commands
{
    class WidthCommand : ICommand
    {
        private readonly Picture picture;

        public string Name => "width";
        public string Help => "Изменить ширину линий";

        public string Description => "Изменяет ширину линий указанных фигур\n" +
                                     "Использование: \'width w x y ..\', где x, y, .. - индексы фигур в команде list," +
                                     " w - ширина линии (целое число >= 0)";

        public string[] Synonyms => new[] {""};

        public WidthCommand(Picture picture)
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
            // Проверяем ошибки во вводе
            var errors = CommandLib.ParseArguments<int>(parameters, out var parsed);
            if (errors.Count != 0)
            {
                Console.WriteLine($"Обнаружены ошибки ввода: {string.Join(", ", errors)}");
                return;
            }
            // Проверяем ширину
            var width = parsed[0];
            if (width < 0)
            {
                Console.WriteLine("Задана неверная ширина");
                return;
            }
            // Проверяем существование индексов
            var cut = parsed.Skip(1).ToList();
            var missing = CommandLib.CheckShapeIndexes(cut, picture, out var indexes);
            if (missing.Count != 0)
            {
                Console.WriteLine($"Отсутствуют фигуры с индексами: {string.Join(", ", missing)}");
            }
            // Выполняем действия
            if (indexes.Count == 0)
            {
                return;
            }
            Console.WriteLine($"Изменяем ширину фигур с индексами: {string.Join(", ", indexes)}");
            foreach (var index in indexes)
            {
                picture.ResizeAt(index, (uint) width);
            }
        }
    }
}