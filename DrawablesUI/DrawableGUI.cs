using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace DrawablesUI
{
    public class DrawableGUI
    {
        private readonly IDrawable picture;
        private readonly Form form;
        private Thread thread;

        public DrawableGUI(IDrawable picture)
        {
            this.picture = picture;
            form = new Form();
        }

        public void Refresh()
        {
            form.Invalidate();
        }

        public void Stop()
        {
            form.Invoke((MethodInvoker) (() =>
            {
                form.Close();
                Application.ExitThread();
            }));
        }

        public void Start()
        {
            thread = new Thread(() =>
            {
                form.Paint += (sender, e) =>
                {
                    using (var x = new GraphicsDrawer(e.Graphics))
                    {
                        picture.Draw(x);
                    }
                };
                form.BackColor = Color.White;
                form.Show();
                Application.Run();
            });
            thread.Start();
        }
    }
}