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

        #endregion

        #region private

        void Render()
        {
            if (_bitmap == null)
                return;

            Graphics g = Graphics.FromImage(_bitmap);
            g.Clear(Color.White);

            Render3DInstance(_instance3D, g, Pens.Black);

            pictureBox1.Image = _bitmap;
        }

        void Render3DInstance(Abstract3DInstance instance, Graphics g, Pen pen)
        {
            if (instance == null)
                return;

            List<Edge> edges = instance.Render();

            foreach(Edge e in edges)
            {
                g.DrawLine(pen, e.point1.ToPointF(), e.point2.ToPointF());
            }
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
            comboBox1.Items.Add("Тетераэдр");
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
        }
    }
}

