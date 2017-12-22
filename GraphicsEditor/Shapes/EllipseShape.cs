using System.Drawing;
using DrawablesUI;

namespace GraphicsEditor.Shapes
{
    /// <inheritdoc />
    /// <summary>
    ///     Класс фигуры "эллипс"
    /// </summary>
    class EllipseShape : IShape
    {
        public PointF Center { get; }
        public SizeF Size { get; }
        public float Degree { get; }
        public FormatInfo Format { get; set; } = new FormatInfo {Color = Color.Black, Width = 1};

        public EllipseShape(PointF center, SizeF size, float rotate)
        {
            Center = center;
            Size = size;
            Degree = rotate;
        }

        public void Draw(IDrawer drawer)
        {
            drawer.SelectPen(Format.Color, (int) Format.Width);
            drawer.DrawEllipseArc(Center, Size, 0, 360, Degree);
        }

        public override string ToString()
        {
            return $"Эллипс(Центр({Center.X}, {Center.Y}), " +
                   $"Размер = ({Size.Height}, {Size.Width})," + $" Угол = {Degree})";
        }
    }
}