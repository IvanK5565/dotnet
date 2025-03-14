using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace lab10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double angle = 0;
        bool isMouseDown = false;
        private void glControl1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
        }
        private void glControl1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }
        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                angle += 15;
                glControl1.Refresh();
            }
        }


        private void glControl1_Resize(object sender, EventArgs e)
        {
            double radius = 2, // Радиус сферы, содержащей всю отображающуюся сцену
            near = 0.01 * radius,
            far = 10 * radius,
            angle = 60,
            h = Math.Tan(angle * Math.PI / 360.0) * near,
            a = (Height == 0) ? 1.0 : (double)Width / (double)Height,
            w = a * h;
            GL.MatrixMode(MatrixMode.Projection); // glMatrixMode(GL_PROJECTION);
            GL.LoadIdentity(); // glLoadIdentity();
            GL.Frustum(-w, w, -h, h, near, far); // glFrustum(-w, w, -h, h, near, far);
            GL.Translate(0, 0, -radius); // glTranslatef(0, 0, -radius);
            GL.Viewport(0, 0, Width, Height); // glViewport(0, 0, width, height);
            GL.MatrixMode(MatrixMode.Modelview); // glMatrixMode(GL_MODELVIEW);
            glControl1.Refresh();
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Translate(-0.25f, -0.25f, -0.25f);
            GL.Rotate(angle, 1, 1, 1); // glRotate(40, 1, 1, 1);
            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(1.0f, 0, 0);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(1, 0, 0);
            GL.Vertex3(0, 1, 0);
            GL.Color3(0, 1.0f, 0);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, 1);
            GL.Vertex3(0, 1, 0);
            GL.Color3(0, 0, 1.0f);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(1, 0, 0);
            GL.Vertex3(0, 0, 1);
            GL.Color3(1.0f, 1.0f, 0);
            GL.Vertex3(1, 0, 0);
            GL.Vertex3(0, 1, 0);
            GL.Vertex3(0, 0, 1);
            GL.End();
            glControl1.SwapBuffers();

        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            // Активізуємо тест глибини (для алгоритму Z-буфера)
            GL.Enable(EnableCap.DepthTest); // glEnable(GL_DEPTH_TEST);
                                            // Задаємо колір фону
            GL.ClearColor(0.5f, 0.5f, 1, 1);
        }
    }
}
