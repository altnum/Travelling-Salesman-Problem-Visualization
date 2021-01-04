using System.Drawing;

namespace TravellingSalesmanProblemVisualization
{
    public struct Town
    {
        private int height;

        private int width;
        
        private Color _color;
        public Point Location
        { get; set; }

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public Town(Point Location, int height, int width, Color color)
        {
            this.Location = Location;
            this.height = height;
            this.width = width;
            _color = color;
        }

        public void Paint(Graphics graphics)
        {
            using (var brush = new SolidBrush(Color.Blue))
            {
                graphics.FillEllipse(brush, Location.X, Location.Y, this.width, this.height);
            }
            using (var pen = new Pen(Color, 3))
            {
                graphics.DrawEllipse(pen, Location.X, Location.Y, this.width, this.height);
            }
        }
        public bool Contains(Point pt)
        {
            if (pt.X >= Location.X && pt.X <= Location.X + width && pt.Y >= Location.Y && pt.Y <= Location.Y + height)
            {
                return true;
            }
            return false;
        }
    }
}
