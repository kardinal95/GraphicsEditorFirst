using System;
using System.Collections.Generic;

namespace GraphicsEditor.Commands
{
    /// <summary>
    ///     Класс содержащий вспомогательные функции для работы команд
    /// </summary>
    static class CommandLib
    {
        /// <summary>
        ///     Обрабатывает входную строку параметров
        /// </summary>
        /// <typeparam name="T">Требуемый тип аргументов</typeparam>
        /// <param name="args">Входная строка параметров</param>
        /// <param name="result">Список конвертированных значений</param>
        /// <returns>Список ошибок</returns>
        public static List<string> ParseArguments<T>(string[] args, out List<T> result)
            where T : IConvertible
        {
            var errors = new List<string>();
            result = new List<T>();
            foreach (var argument in args)
            {
                try
                {
                    var temp = (T) Convert.ChangeType(argument, typeof(T));
                    result.Add(temp);
                }
                catch (Exception e) when (e is OverflowException || e is FormatException)
                {
                    errors.Add(argument);
                }
            }
            return errors;
        }

        /// <summary>
        ///     Проверяет существование фигур с указанными индексами на картинке
        /// </summary>
        /// <param name="indexes">Входные индексы</param>
        /// <param name="picture">Обьект изображения</param>
        /// <param name="parsed">Список существующих индексы</param>
        /// <returns>Список несуществующих индексов</returns>
        public static List<int> CheckShapeIndexes(List<int> indexes, Picture picture,
                                                  out List<int> parsed)
        {
            parsed = new List<int>();
            var errors = new List<int>();
            var shapes = picture.GetShapes();
            var previous = -1;
            indexes.Sort();
            indexes.Reverse(); // Обрабатывать будем с элемента со старшим индексом чтобы избежать ошибок
            foreach (var index in indexes)
            {
                if (index >= shapes.Length || index < 0)
                {
                    errors.Add(index);
                }
                else if (previous == index)
                {
                    errors.Add(index);
                }
                else
                {
                    parsed.Add(index);
                }
                previous = index;
            }
            return errors;
        }
    }
}