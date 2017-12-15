using System;
using System.Collections.Generic;

namespace GraphicsEditor.Commands
{
    /// <summary>
    ///     Класс содержащий вспомогательные функции для работы команд
    /// </summary>
    static class CommandLib
    {
        public static List<string> ParseArguments(string[] args, out List<float> result)
        {
            var errors = new List<string>();
            result = new List<float>();
            foreach (var argument in args)
            {
                try
                {
                    var parsed = float.Parse(argument);
                    result.Add(parsed);
                }
                catch (Exception e) when (e is OverflowException || e is FormatException)
                {
                    errors.Add(argument);
                }
            }
            return errors;
        }

        public static List<string> ParseArguments(string[] args, out List<int> result)
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