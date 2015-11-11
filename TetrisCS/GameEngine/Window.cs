using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TetrisCS.GameEngine
{

    public abstract class Window<TWindowIdType> : Form
    {
        public event EventHandler InitializeWindow;
        public event EventHandler EnterWindow;
        public event EventHandler LeaveWindow;

        protected Panel Canvas;
        protected readonly Engine<TWindowIdType> Engine;

        public abstract TWindowIdType Id { get; }

        protected Window(Engine<TWindowIdType> engine)
        {
            Engine = engine;
            InitializeComponent();
        }

        public void OnInitializeWindow(EventArgs e)
        {
            InitializeWindow?.Invoke(this, e);
        }

        public void OnEnterWindow(EventArgs e)
        {
            EnterWindow?.Invoke(this, e);
        }

        public void OnLeaveWindow(EventArgs e)
        {
            LeaveWindow?.Invoke(this, e);
        }

        public abstract void RenderWindow(Graphics g);

        public abstract void UpdateWindow(int delta);

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            //Console.WriteLine(e.Graphics);
            Engine.Start(Canvas.CreateGraphics());
        }

        private void InitializeComponent()
        {
            var w = int.Parse(ConfigurationManager.AppSettings["Width"]);
            var h = int.Parse(ConfigurationManager.AppSettings["Height"]);
            this.Canvas = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(w, h);
            Canvas.Paint += Canvas_Paint;
            this.Canvas.TabIndex = 0;

            // 
            // Window
            // 
            this.ClientSize = new System.Drawing.Size(w, h);
            this.Controls.Add(this.Canvas);
            this.Name = "Window";
            this.ResumeLayout(false);
            DoubleBuffered = true;
        }
    }
}
