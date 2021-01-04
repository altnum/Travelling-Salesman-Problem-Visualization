using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TravellingSalesmanProblemVisualization
{
    public partial class TravellingSalesman : Form
    {
        private static LinkedList<Town> towns = new LinkedList<Town>();
        public static string routes = "";
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
            if (routes.Length > 1)
            {
                DrawPerRoute(routes, e);
            }
        }

        protected void addTown(Point location, Color color)
        {
            Town newTown = new Town(location, 5, 5, color);

            towns.AddLast(newTown);

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

        private void Start_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "DynamicProgramming")
            {
                DynamicProgrammingTSP(towns);
            }
        }

        public void DynamicProgrammingTSP(LinkedList<Town> towns)
        {
            var distances = new int[towns.Count, towns.Count];

            for (int i = 0; i < towns.Count; i++)
            {
                for (int j = 0; j < towns.Count; j++)
                {
                    if (i == j)
                    {
                        distances[i, j] = -1;
                    }
                    else
                    {
                        distances[i, j] = int.Parse(Math.Ceiling(Math.Sqrt(Math.Pow(towns.ElementAt(i).Location.X - towns.ElementAt(j).Location.X, 2) + Math.Pow(towns.ElementAt(i).Location.Y - towns.ElementAt(j).Location.Y, 2))).ToString());
                    }
                }
            }

            string route = "";
            DPTSP(distances, 0, new List<int>(), out route);

            routes = route;

            Invalidate();
        }

        public int DPTSP(int[,] costs, int from, List<int> visited, out string route)
        {
            route = "";

            if (visited.Count() + 1 == costs.GetLength(0))
            {
                route = from.ToString();
                routes = route;
                Invalidate();
                Update();
                return costs[from, 0];
            }

            visited.Add(from);

            var min = int.MaxValue;
            for (int to = 0; to < costs.GetLength(0); to++)
            {
                if (!visited.Contains(to) && costs[from, to] != -1)
                {
                    var subRoute = "";
                    var subSolution = DPTSP(costs, to, visited, out subRoute);

                    if (subSolution == -1)
                        continue;

                    var value = costs[from, to] + subSolution;

                    if (value < min)
                    {
                        route = from + " " + subRoute;
                        min = value;
                        routes = route;
                        Invalidate();
                        Update();
                    }
                }
            }

            visited.Remove(from);

            return min == int.MaxValue ? -1 : min;
        }

        public static void DrawPerRoute(string route, PaintEventArgs e)
        {
            int[] routeNodes = Array.ConvertAll<string, int>(route.Split(' '), int.Parse);

            using (var p = new Pen(Color.Black, 2))
            {
                for (int i = 0; i < routeNodes.Length - 1; i++)
                {

                    e.Graphics.DrawLine(p, towns.ElementAt(routeNodes[i]).Location, towns.ElementAt(routeNodes[i + 1]).Location);
                    if (routeNodes.Length == towns.Count && i == routeNodes.Length - 2)
                    {
                        e.Graphics.DrawLine(p, towns.ElementAt(routeNodes[i + 1]).Location, towns.ElementAt(routeNodes[0]).Location);
                    }
                }
            }
        }
    }
}
