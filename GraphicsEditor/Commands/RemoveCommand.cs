using System;
using ConsoleUI;

namespace GraphicsEditor.Commands
{
    class RemoveCommand : ICommand
    {
        private readonly Picture picture;

        public string Name => "remove";
        public string Help => "Удалить фигуры с картинки";

        public string Description => "Удаляет фигуры с указанными индексами\n" +
                                     "Использование: \'remove x y ..\', где x, y, .. - индексы фигур в команде list";

        public string[] Synonyms => new[] {"rm"};

        public RemoveCommand(Picture picture)
        {
            this.picture = picture;
        }

        public void Execute(params string[] parameters)
        {
            var errors = CommandLib.ParseArguments<int>(parameters, out var parsed);
            if (errors.Count != 0)
            {
                Console.WriteLine($"Обнаружены ошибки ввода: {string.Join(", ", errors)}");
                return;
            }
            var missing = CommandLib.CheckShapeIndexes(parsed, picture, out var indexes);
            if (missing.Count != 0)
            {
                Console.WriteLine($"Отсутствуют фигуры с индексами: {string.Join(", ", missing)}");
            }
            if (indexes.Count == 0)
            {
                return;
            }
            Console.WriteLine($"Удаляем фигуры с индексами: {string.Join(", ", indexes)}");
            foreach (var index in indexes)
            {
                picture.RemoveAt(index);
            }
        }
    }
}