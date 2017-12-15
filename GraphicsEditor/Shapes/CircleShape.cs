using System.Drawing;
using DrawablesUI;

namespace GraphicsEditor.Shapes
{
    /// <inheritdoc />
    /// <summary>
    ///     Класс фигуры "круг"
    /// </summary>
    class CircleShape : IShape
    {
        public PointF Center { get; }
        public float Radius { get; }
        public FormatInfo Format { get; set; } = new FormatInfo {Color = Color.Black, Width = 1};

        public CircleShape(PointF center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        public void Draw(IDrawer drawer)
        {
            drawer.SelectPen(Format.Color, (int) Format.Width);
            var size = new SizeF(2 * Radius, 2 * Radius);
            drawer.DrawEllipseArc(Center, size);
        }

        public override string ToString()
        {
            return $"Круг(Центр({Center.X}, {Center.Y}), Радиус = {Radius})";
        }
    }
}