using System;
using ConsoleUI;

namespace GraphicsEditor.Commands
{
    class ListCommand : ICommand
    {
        private readonly Picture picture;

        public string Name => "list";
        public string Help => "Вывести список фигур на картинке";
        public string Description => "";
        public string[] Synonyms => new[] {""};

        public ListCommand(Picture picture)
        {
            this.picture = picture;
        }

        public void Execute(params string[] parameters)
        {
            var shapes = picture.GetShapes();
            for (var i = 0; i < shapes.Length; i++)
            {
                Console.WriteLine($"[{i}] - {shapes[i]}");
            }
        }
    }
}