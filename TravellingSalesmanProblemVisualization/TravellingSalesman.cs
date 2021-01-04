using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravellingSalesmanProblemVisualization
{
    public partial class TravellingSalesman : Form
    {
        private List<Town> towns = new List<Town>();
        public TravellingSalesman()
        {
            InitializeComponent();

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);
        }

        public void DrawImage2FloatRectF(PaintEventArgs e)
        {
            Image newImage = Image.FromFile("D:\\Travelling salesman problem visualization\\TravellingSalesmanProblemVisualization\\Resources\\3178.png");

            float x = 130.0F;
            float y = 0.0F;

            RectangleF srcRect = new RectangleF(0.0F, 0.0F, 930.0F, 723.0F);
            GraphicsUnit units = GraphicsUnit.Pixel;

            e.Graphics.DrawImage(newImage, x, y, srcRect, units);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawImage2FloatRectF(e);
            base.OnPaint(e);
            foreach (Town t in towns)
            {
                t.Paint(e.Graphics);
            }
        }

        protected void addTown(Point location, Color color)
        {
            Town newTown = new Town(location, 5, 5, color);

            towns.Add(newTown);

            using (var graphics = CreateGraphics())
            {
                newTown.Paint(graphics);
            }
        }

            private void TravellingSalesman_MouseUp(object sender, MouseEventArgs e)
        {
            if (towns.Count > 0 && towns.Count < 30 && AddTowns.Checked) {
                Point location = new Point(e.Location.X, e.Location.Y);
                addTown(location, Color.Blue);
            }
            else if (towns.Count > 0 && towns.Count <= 30 && RemoveTowns.Checked)
            {
                List<Town> townsForRemoving = towns.Where(town => town.Contains(e.Location)).ToList();

                foreach (Town t in townsForRemoving)
                {
                    if (towns.Count > 1)
                    {
                        if (t.Color != Color.Red)
                        {
                            towns.Remove(t);
                            Invalidate();
                        }
                    } 
                    else
                    {
                        towns.Remove(t);
                        Invalidate();
                    }
                }
            }
            else if (towns.Count == 0 && AddTowns.Checked)
            {
                Point location = new Point(e.Location.X, e.Location.Y);
                addTown(location, Color.Red);
            }
        }

        private void RemoveAllTowns_Click(object sender, EventArgs e)
        {
            towns.Clear();
            Invalidate();
        }

        private void TravellingSalesman_Load(object sender, EventArgs e)
        {

        }
    }
}
