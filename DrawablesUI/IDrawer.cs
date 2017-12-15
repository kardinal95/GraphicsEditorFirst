using System.Drawing;

namespace DrawablesUI
{
    public interface IDrawer
    {
        void SelectPen(Color color, int width=1);
        void DrawPoint(PointF point);
        void DrawLine(PointF start, PointF end);
        void DrawEllipseArc(PointF center, SizeF size, 
            float startAngle=0, float endAngle=360, float rotate=0);
    }
}