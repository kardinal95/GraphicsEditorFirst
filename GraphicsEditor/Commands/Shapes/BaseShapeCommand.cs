using System;
using System.Collections.Generic;
using ConsoleUI;
using GraphicsEditor.Shapes;

namespace GraphicsEditor.Commands.Shapes
{
    /// <inheritdoc />
    /// <summary>
    ///     Класс для базовой реализации команд добавления фигур
    ///     Фигуры должны принимать в качестве аргументов произвольное количество чисел float
    /// </summary>
    abstract class BaseShapeCommand : ICommand
    {
        public abstract string Name { get; }
        public abstract string Help { get; }
        public abstract string Description { get; }
        public abstract string[] Synonyms { get; }

        protected abstract int Argsnum { get; } // Количество аргументов для команды
        private readonly Picture picture;

        protected BaseShapeCommand(Picture picture)
        {
            this.picture = picture;
        }

        /// <summary>
        ///     Реализация метода должна создать фигуру <see cref="IShape" />
        /// </summary>
        /// <param name="parsed">Список обработанных аргументов</param>
        /// <returns>Созданная фигура</returns>
        public abstract IShape CreateShape(List<float> parsed);

        /// <summary>
        ///     Исполнение команды. Проверяет входные параметры на ошибки
        ///     При нахождении - выводит
        ///     При остутствии - создает фигуру вызовом <see cref="CreateShape" />, и
        ///     добавляет её на лист
        /// </summary>
        /// <param name="parameters">Строка входных аргументов</param>
        public void Execute(params string[] parameters)
        {
            if (parameters.Length != Argsnum)
            {
                Console.WriteLine("Ошибка - некорректное количество аргументов!");
                return;
            }
            var errors = CommandLib.ParseArguments<float>(parameters, out var parsed);
            if (errors.Count != 0)
            {
                Console.WriteLine($"Обнаружены ошибки ввода: {string.Join(", ", errors)}");
                return;
            }
            picture.Add(CreateShape(parsed));
        }
    }
}