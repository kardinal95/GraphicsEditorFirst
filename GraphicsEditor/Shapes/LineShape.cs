using System.Drawing;
using DrawablesUI;

namespace GraphicsEditor.Shapes
{
    /// <inheritdoc />
    /// <summary>
    ///     Класс фигуры "линия"
    /// </summary>
    class LineShape : IShape
    {
        public PointF Start { get; }
        public PointF End { get; }
        public FormatInfo Format { get; set; } = new FormatInfo {Color = Color.Black, Width = 1};

        public LineShape(PointF start, PointF end)
        {
            Start = start;
            End = end;
        }

        public void Draw(IDrawer drawer)
        {
            drawer.SelectPen(Format.Color, (int) Format.Width);
            drawer.DrawLine(Start, End);
        }

        public override string ToString()
        {
            return $"Линия(Точка({Start.X}, {Start.Y}), Точка({End.X}, {End.Y}))";
        }
    }
}