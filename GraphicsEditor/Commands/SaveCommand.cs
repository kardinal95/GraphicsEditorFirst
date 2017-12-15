using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using ConsoleUI;

namespace GraphicsEditor.Commands
{
    class SaveCommand : ICommand
    {
        private readonly Picture picture;

        public string Name => "save";
        public string Help => "Сохранить текущее изображение";
        public string Description => "";
        public string[] Synonyms => new[] {"sv"};

        public SaveCommand(Picture picture)
        {
            this.picture = picture;
        }

        public void Execute(params string[] parameters)
        {
            if (parameters.Length == 0)
            {
                Console.WriteLine("Не указано имя файла!");
                return;
            }
            if (parameters.Length > 1)
            {
                Console.WriteLine("Указано больше одного аргумента!");
                return;
            }
            CheckFilename(parameters[0]);
            var shapes = picture.GetShapes();

        }

        private static bool CheckFilename(string filename)
        {
            return !System.IO.File.Exists(filename);
        }
    }
}