using System.Collections.Generic;
using System.Drawing;
using GraphicsEditor.Shapes;

namespace GraphicsEditor.Commands.Shapes
{
    class EllipseCommand : BaseShapeCommand
    {
        protected override int Argsnum => 5;

        public override string Name => "ellipse";
        public override string Help => "Нарисовать эллипс";

        public override string Description =>
            "Рисует эллипс по координатам x, y с размерами m, n и углом поворота f.\n" +
            "Использование: \'ellipse x y m n f\', где x, y, m, n, f - числа";

        public override string[] Synonyms => new[] {"elp"};

        public override IShape CreateShape(List<float> parsed)
        {
            var center = new PointF(parsed[0], parsed[1]);
            var size = new SizeF(parsed[2], parsed[3]);
            return new EllipseShape(center, size, parsed[4]);
        }

        public EllipseCommand(Picture picture) : base(picture) { }
    }
}