using System.Drawing;
using DrawablesUI;

namespace GraphicsEditor.Shapes
{
    /// <inheritdoc />
    /// <summary>
    ///     Класс фигуры "точка"
    /// </summary>
    class PointShape : IShape
    {
        public PointF Coordinates { get; }
        public FormatInfo Format { get; set; } = new FormatInfo {Color = Color.Black, Width = 1};

        public PointShape(float x, float y)
        {
            Coordinates = new PointF(x, y);
        }

        public void Draw(IDrawer drawer)
        {
            drawer.SelectPen(Format.Color, (int) Format.Width);
            drawer.DrawPoint(Coordinates);
        }

        public override string ToString()
        {
            return $"Точка({Coordinates.X}, {Coordinates.Y})";
        }
    }
}