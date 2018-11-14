using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple3D
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        #region memebers

        Bitmap _bitmap = null;
        Abstract3DInstance _instance3D = null;
        PointF _startPoint = PointF.Empty;
        double _scaleFactor = 1;

        #endregion

        #region private

        void Render()
        {
            if (_bitmap == null)
                return;

            Graphics g = Graphics.FromImage(_bitmap);
            g.Clear(Color.White);

            // отрисовываем 3D объект.
            Render3DInstance(_instance3D, g);

            pictureBox1.Image = _bitmap;
        }

        void Render3DInstance(Abstract3DInstance instance, Graphics g)
        {
            if (instance == null)
                return;

            Pen pen = new Pen(Color.Black, 2f);
            List<Edge> edges = instance.Render();

            foreach(Edge e in edges.Where(x => x.Visible))
            {
                g.DrawLine(pen, e.point1.ToPointF(), e.point2.ToPointF());
            }
        }

        void FirstTransformation(Abstract3DInstance instance, double Xc, double Yc)
        {
            if (instance == null)
                return;

            TransformEngine.Scale(instance, 140, 0, 0, 0);
            TransformEngine.Translate(instance, Xc, Yc, 0);

            _scaleFactor = 1;
        }

        bool CreateBackground()
        {
            if (pictureBox1.Width < 1 || pictureBox1.Height < 1)
            {
                _bitmap = null;
                return false;
            }

            _bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            return true;
        }

        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.White;
            CreateBackground();

            comboBox1.Items.Add("Куб");
            comboBox1.Items.Add("Тетраэдр");
            comboBox1.SelectedIndex = 0;
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            CreateBackground();
        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;

            if (index < 0)
                return;

            _instance3D = Factory3Dinstance.GetInstance(index);
            FirstTransformation(_instance3D, pictureBox1.Width / 2, pictureBox1.Height / 2);
            trackBar1.Value = (trackBar1.Minimum + trackBar1.Maximum) / 2;

            Render();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_instance3D == null)
                return;

            if (e.Button == MouseButtons.Left)
            {
                PointF point = new PointF(e.X, e.Y);

                double angleXZ = (point.X - _startPoint.X) / 52;
                double angleYZ = (point.Y - _startPoint.Y) / 52;

                TransformEngine.RotateXZ(_instance3D, angleXZ, pictureBox1.Width / 2, 0);
                TransformEngine.RotateYZ(_instance3D, angleYZ, pictureBox1.Height / 2, 0);

                Render();

                _startPoint = point;
            }          
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _startPoint = new PointF(e.X, e.Y);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (_instance3D == null)
                return;

            const double c_min = 0.5;
            const double c_max = 2;

            double sf = (c_max - c_min) / Convert.ToDouble(trackBar1.Maximum - trackBar1.Minimum) * Convert.ToDouble(trackBar1.Value - trackBar1.Minimum) + c_min;

            TransformEngine.Scale(_instance3D, sf / _scaleFactor, pictureBox1.Width / 2, pictureBox1.Height / 2, 0);
            _scaleFactor = sf;

            Render();
        }
    }
}

