using System.Drawing;
using DrawablesUI;

namespace GraphicsEditor.Shapes
{
    /// <summary>
    ///     Определяет хранение формата <see cref="FormatInfo" /> для фигуры
    ///     Расширяет интерфейс <see cref="IDrawable" />
    /// </summary>
    public interface IShape : IDrawable
    {
        FormatInfo Format { get; set; }
    }

    /// <summary>
    ///     Класс для хранения данных о формате фигуры
    /// </summary>
    public class FormatInfo
    {
        public Color Color { get; set; }
        public uint Width { get; set; }
    }
}