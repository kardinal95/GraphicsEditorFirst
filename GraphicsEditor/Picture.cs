using System;
using System.Collections.Generic;
using System.Drawing;
using DrawablesUI;
using GraphicsEditor.Shapes;

namespace GraphicsEditor
{
    public class Picture : IDrawable
    {
        private readonly List<IShape> shapes = new List<IShape>();
        private readonly object lockObject = new object();

        public event Action Changed;

        public void Remove(IShape shape)
        {
            lock (lockObject)
            {
                shapes.Remove(shape);
            }
        }

        public void RemoveAt(int index)
        {
            lock (lockObject)
            {
                shapes.RemoveAt(index);
                Changed?.Invoke();
            }
        }

        public void Add(IShape shape)
        {
            lock (lockObject)
            {
                shapes.Add(shape);
                Changed?.Invoke();
            }
        }

        public void Add(int index, IShape shape)
        {
            lock (lockObject)
            {
                shapes.Insert(index, shape);
                Changed?.Invoke();
            }
        }

        public void Draw(IDrawer drawer)
        {
            lock (lockObject)
            {
                foreach (var shape in shapes)
                {
                    shape.Draw(drawer);
                }
            }
        }

        public IShape[] GetShapes()
        {
            lock (lockObject)
            {
                return shapes.ToArray();
            }
        }

        public void RecolorAt(int index, Color color)
        {
            lock (lockObject)
            {
                shapes[index].Format.Color = color;
                Changed?.Invoke();
            }
        }

        public void ResizeAt(int index, uint width)
        {
            lock (lockObject)
            {
                shapes[index].Format.Width = width;
                Changed?.Invoke();
            }
        }
    }
}