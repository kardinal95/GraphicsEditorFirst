using System.Collections.Generic;
using System.Drawing;
using GraphicsEditor.Shapes;

namespace GraphicsEditor.Commands.Shapes
{
    class LineCommand : BaseShapeCommand
    {
        protected override int Argsnum => 4;

        public override string Name => "line";
        public override string Help => "Нарисовать линию";

        public override string Description =>
            "Рисует линию по точкам с координатами (x1, y1), (x2, y2).\n" +
            "Использование: \'line x1 y1 x2 y2\', где x1, y1, x2, y2 - числа";

        public override string[] Synonyms => new[] {"ln"};

        public override IShape CreateShape(List<float> parsed)
        {
            var pointStart = new PointF(parsed[0], parsed[1]);
            var pointEnd = new PointF(parsed[2], parsed[3]);
            return new LineShape(pointStart, pointEnd);
        }

        public LineCommand(Picture picture) : base(picture) { }
    }
}