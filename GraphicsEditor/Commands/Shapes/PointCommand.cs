using System.Collections.Generic;
using GraphicsEditor.Shapes;

namespace GraphicsEditor.Commands.Shapes
{
    class PointCommand : BaseShapeCommand
    {
        protected override int Argsnum => 2;

        public override string Name => "point";
        public override string Help => "Нарисовать точку";

        public override string Description => "Рисует точку по координатам x, y.\n" +
                                              "Использование: \'point x y\', где x,y - числа типа float";

        public override string[] Synonyms => new[] {"pt"};

        public override IShape CreateShape(List<float> parsed)
        {
            return new PointShape(parsed[0], parsed[1]);
        }

        public PointCommand(Picture picture) : base(picture) { }
    }
}