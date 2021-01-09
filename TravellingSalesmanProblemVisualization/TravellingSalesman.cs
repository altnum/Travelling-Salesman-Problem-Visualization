using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace TravellingSalesmanProblemVisualization
{
    public partial class TravellingSalesman : Form
    {
        private static LinkedList<Town> towns = new LinkedList<Town>();
        public static string routes = "";
        public static string bestRoute = "";
        public static int[,] distancesDPTSP;
        public static int[,] distancesBBTSP;
        public static bool closedController = true;
        public bool pressedStop = false;
        public ManualResetEvent mre;
        public bool finishedCalc = false;
        StopController controllerForm;
        string selectedItem = "";

        static int n;
        static int curSum, minSum;
        static char[] used;
        static int[] minCycle;
        static int[] cycle;

        public static int minAns = int.MaxValue;
        public static string newRoute;
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
            if (towns.Count > 0)
            {
                foreach (Town t in towns)
                {
                    t.Paint(e.Graphics);
                }
            }
            if (routes.Length > 1)
            {
                if (selectedItem == "DynamicProgramming")
                    DrawPerRouteDP(routes, e);
                else if (selectedItem == "Branch&Bound")
                    DrawPerRouteBB(routes, e);
                else if (selectedItem == "Backtracking")
                    DrawPerRouteBT(routes, e);
            }
        }

        protected void addTown(Point location, Color color)
        {
            if (towns.Count <= 10)
            {
                Town newTown = new Town(location, 5, 5, color);


                towns.AddLast(newTown);

                using (var graphics = CreateGraphics())
                {
                    newTown.Paint(graphics);
                }
            }
        }

        private void TravellingSalesman_MouseUp(object sender, MouseEventArgs e)
        {
            if (towns.Count > 0 && towns.Count < 30 && AddTowns.Checked)
            {
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
            routes = "";
            Invalidate();
        }

        private void TravellingSalesman_Load(object sender, EventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (towns.Count > 2)
            {
                if (comboBox1.SelectedItem != null)
                    selectedItem = comboBox1.SelectedItem.ToString();

                if (selectedItem != "")
                {

                    Program.travellingSalesman.Enabled = false;
                    Thread controller = new Thread(openController);
                    controller.Start();


                    switch (selectedItem)
                    {
                        case "DynamicProgramming":
                            DynamicProgrammingTSP(towns);
                            if (!pressedStop)
                            {
                                Control.CheckForIllegalCrossThreadCalls = false;
                                controllerForm.timer1.Enabled = false;
                                mre = new ManualResetEvent(false);
                                mre.WaitOne();
                            }
                            finishedCalc = true;
                            pressedStop = true;
                            break;
                        case "Branch&Bound":
                            BranchAndBoundTSP(towns);
                            if (!pressedStop)
                            {
                                Control.CheckForIllegalCrossThreadCalls = false;
                                controllerForm.timer1.Enabled = false;
                                mre = new ManualResetEvent(false);
                                mre.WaitOne();
                            }
                            finishedCalc = true;
                            pressedStop = true;
                            break;
                        case "Backtracking":
                            BacktrackingTSP(towns);
                            if (!pressedStop)
                            {
                                Control.CheckForIllegalCrossThreadCalls = false;
                                controllerForm.timer1.Enabled = false;
                                mre = new ManualResetEvent(false);
                                mre.WaitOne();
                            }
                            finishedCalc = true;
                            pressedStop = true;
                            break;
                    }

                    if (pressedStop && finishedCalc)
                    {
                        routes = "";
                        distanceStatus.Text = "Distance in km: ";
                        pressedStop = false;
                        finishedCalc = false;
                    }

                    controller.Abort();
                    Invalidate();
                    Update();
                }
            }
        }

        public void openController()
        {
            controllerForm = new StopController();
            controllerForm.ShowDialog();
        }

        public void DrawPerRouteDP(string route, PaintEventArgs e)
        {
            int[] routeNodes = Array.ConvertAll<string, int>(route.Split(' '), int.Parse);
            int distance = 0;

            using (var p = new Pen(Color.Black, 2))
            {
                for (int i = 0; i < routeNodes.Length - 1; i++)
                {
                    if (routeNodes.Length - 1 == towns.Count && i == routeNodes.Length - 2)
                    {
                        e.Graphics.DrawLine(p, towns.ElementAt(routeNodes[i]).Location, towns.ElementAt(routeNodes[0]).Location);
                        distance += distancesDPTSP[routeNodes[i], routeNodes[0]];
                    }
                    else
                    {
                        e.Graphics.DrawLine(p, towns.ElementAt(routeNodes[i]).Location, towns.ElementAt(routeNodes[i + 1]).Location);
                        distance += distancesDPTSP[routeNodes[i], routeNodes[i + 1]];
                    }


                }
            }

            distanceStatus.Text = "Distance in km: " + distance;
        }

        public void DrawPerRouteBT(string route, PaintEventArgs e)
        {
            int[] routeNodes = new int[route.Length];
            for (int i = 0; i < route.Length; i++)
            {
                routeNodes[i] = int.Parse(route[i].ToString());
            }
            int distance = 0;

            using (var p = new Pen(Color.Black, 2))
            {
                for (int i = 0; i < routeNodes.Length - 1; i++)
                {
                    e.Graphics.DrawLine(p, towns.ElementAt(routeNodes[i]).Location, towns.ElementAt(routeNodes[i + 1]).Location);
                    distance += distancesDPTSP[routeNodes[i], routeNodes[i + 1]];    
                }
            }

            distanceStatus.Text = "Distance in km: " + distance;
        }

        public void DrawPerRouteBB(string route, PaintEventArgs e)
        {
            route = "0" + route;
            int[] routeNodes = new int[route.Length];
            for (int i = 0; i < route.Length; i++)
            {
                routeNodes[i] = int.Parse(route[i].ToString());
            }
            int distance = 0;

            using (var p = new Pen(Color.Black, 2))
            {
                for (int i = 0; i < routeNodes.Length - 1; i++)
                {
                    if (routeNodes.Length == towns.Count && i == routeNodes.Length - 2)
                    {
                        e.Graphics.DrawLine(p, towns.ElementAt(routeNodes[i]).Location, towns.ElementAt(routeNodes[i + 1]).Location);
                        distance += distancesBBTSP[routeNodes[i], routeNodes[i + 1]];
                        e.Graphics.DrawLine(p, towns.ElementAt(routeNodes[i + 1]).Location, towns.ElementAt(routeNodes[0]).Location);
                        distance += distancesBBTSP[routeNodes[i + 1], routeNodes[0]];
                    }
                    else
                    {
                        e.Graphics.DrawLine(p, towns.ElementAt(routeNodes[i]).Location, towns.ElementAt(routeNodes[i + 1]).Location);
                        distance += distancesBBTSP[routeNodes[i], routeNodes[i + 1]];
                    }
                }
            }

            distanceStatus.Text = "Distance in km: " + distance;
        }

        public void DynamicProgrammingTSP(LinkedList<Town> towns)
        {
            distancesDPTSP = new int[towns.Count, towns.Count];

            for (int i = 0; i < towns.Count; i++)
            {
                for (int j = 0; j < towns.Count; j++)
                {
                    if (i == j)
                    {
                        distancesDPTSP[i, j] = -1;
                    }
                    else
                    {
                        distancesDPTSP[i, j] = int.Parse(Math.Ceiling((int.Parse(Math.Ceiling(Math.Sqrt(Math.Pow(towns.ElementAt(i).Location.X - towns.ElementAt(j).Location.X, 2) + Math.Pow(towns.ElementAt(i).Location.Y - towns.ElementAt(j).Location.Y, 2))).ToString()) / 3) * 1.8).ToString());
                    }
                }
            }

            string route = "";
            DPTSP(distancesDPTSP, 0, new List<int>(), out route);
        }

        public void BranchAndBoundTSP(LinkedList<Town> towns)
        {
            distancesBBTSP = new int[towns.Count, towns.Count];

            for (int i = 0; i < towns.Count; i++)
            {
                for (int j = 0; j < towns.Count; j++)
                {
                    if (i == j)
                    {
                        distancesBBTSP[i, j] = 0;
                    }
                    else
                    {
                        distancesBBTSP[i, j] = int.Parse(Math.Ceiling((int.Parse(Math.Ceiling(Math.Sqrt(Math.Pow(towns.ElementAt(i).Location.X - towns.ElementAt(j).Location.X, 2) + Math.Pow(towns.ElementAt(i).Location.Y - towns.ElementAt(j).Location.Y, 2))).ToString()) / 3) * 1.8).ToString());
                    }
                }
            }

            n = distancesBBTSP.GetLength(0);
            used = new char[n];
            minCycle = new int[n];
            cycle = new int[n];

            int k;
            for (k = 0; k < n; k++)
            {
                used[k] = (char)0;
            }
            minSum = int.MaxValue;
            curSum = 0;
            cycle[0] = 1;
            BBTSP(0, 0);
        }

        private void BacktrackingTSP(LinkedList<Town> towns)
        {
            distancesDPTSP = new int[towns.Count, towns.Count];

            for (int i = 0; i < towns.Count; i++)
            {
                for (int j = 0; j < towns.Count; j++)
                {
                    if (i == j)
                    {
                        distancesDPTSP[i, j] = 0;
                    }
                    else
                    {
                        distancesDPTSP[i, j] = int.Parse(Math.Ceiling((int.Parse(Math.Ceiling(Math.Sqrt(Math.Pow(towns.ElementAt(i).Location.X - towns.ElementAt(j).Location.X, 2) + Math.Pow(towns.ElementAt(i).Location.Y - towns.ElementAt(j).Location.Y, 2))).ToString()) / 3) * 1.8).ToString());
                    }
                }
            }

            routes = "";
            bestRoute = "";
            int n = distancesDPTSP.GetLength(0);
            bool[] v = new bool[n];
            v[0] = true;
            int ans = int.MaxValue;
            minAns = int.MaxValue;
            BTTSP(distancesDPTSP, v, 0, n, 1, 0, ans);
            routes = bestRoute;
            Invalidate();
            Update();
        }

        public int BTTSP(int[,] graph, bool[] v, int currPos, int n, int count, int cost, int ans)
        {
            if (count == n && graph[currPos, 0] > 0)
            {

                if (cost + graph[currPos, 0] < ans)
                {
                    routes += currPos.ToString() + "0";
                    bestRoute = routes;
                    Console.WriteLine(routes);
                    Invalidate();
                    Update();

                    newRoute = "";
                    for (int j = 0; j < routes.Length; j++)
                    {
                        if (j == routes.Length - 2)
                            break;
                        newRoute += routes[j];
                    }
                    routes   = newRoute;
                }
                ans = Math.Min(ans, cost + graph[currPos, 0]);
                return ans;
            }
            
            for (int i = 0; i < n; i++)
            {
                if (v[i] == false && graph[currPos, i] > 0)
                {
                    v[i] = true;
                    routes += currPos;
                    Invalidate();
                    Update();
                    ans = BTTSP(graph, v, i, n, count + 1, cost + graph[currPos, i], ans);
                    
                    mre = new ManualResetEvent(false);

                    if (pressedStop)
                    {
                        if (!finishedCalc)
                            mre.WaitOne();
                        
                        if (pressedStop && finishedCalc)
                        {
                            return -1;
                        }
                    }

                    newRoute = "";

                    for (int j = 0; j < routes.Length; j++)
                    {
                        if (j == routes.Length - 1)
                            break;
                        newRoute += routes[j];
                    }
                    routes = newRoute;
                    
                    v[i] = false;
                }
            }
            Invalidate();
            Update();

            return ans;
            
        }

        public int DPTSP(int[,] costs, int from, List<int> visited, out string route)
        {
            route = "";

            if (visited.Count() + 1 == costs.GetLength(0))
            {
                route = from.ToString() + " 0";
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

                    mre = new ManualResetEvent(false);

                    if (pressedStop)
                    {
                        if (!finishedCalc)
                            mre.WaitOne();

                        if (pressedStop && finishedCalc)
                        {
                            return -1;
                        }
                    }

                    if (subSolution == -1)
                        continue;

                    var value = costs[from, to] + subSolution;

                    if (value < min)
                    {
                        route = from + " " + subRoute;
                        routes = route;
                        Invalidate();
                        Update();
                        min = value;
                    }

                    routes = route;
                    Invalidate();
                    Update();
                }
            }

            visited.Remove(from);

            return min == int.MaxValue ? -1 : min;
        }

        public static void BBTSP(int i, int level)
        {
            if ((i == 0) && (level > 0))
            {
                if (level == n)
                {
                    minSum = curSum;
                    for (int k = 0; k < n; k++)
                        minCycle[k] = cycle[k];
                }
                return;
            }
            if (used[i] == 1)
                return;

            used[i] = (char)1;

            for (int k = 0; k < n; k++)
                if (distancesBBTSP[i, k] != 0 && k != i)
                {
                    cycle[level] = k;
                    curSum += distancesBBTSP[i, k];

                    foreach (int z in minCycle)
                    {
                        if (z != 0)
                            routes = routes + z;
                    }

                    Program.travellingSalesman.Invalidate();
                    Program.travellingSalesman.Update();
                    Console.WriteLine(routes);
                    routes = "";

                    if (curSum < minSum)
                        BBTSP(k, level + 1);



                    Program.travellingSalesman.mre = new ManualResetEvent(false);

                    if (Program.travellingSalesman.pressedStop)
                    {
                        if (!Program.travellingSalesman.finishedCalc)
                            Program.travellingSalesman.mre.WaitOne();

                        if (Program.travellingSalesman.pressedStop && Program.travellingSalesman.finishedCalc)
                        {
                            return;
                        }
                    }

                    curSum -= distancesBBTSP[i, k];
                }
            used[i] = (char)0;
        }
    }
}
