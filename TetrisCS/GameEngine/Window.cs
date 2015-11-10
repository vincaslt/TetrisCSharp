using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TetrisCS.GameEngine
{

    public abstract class Window<TWindowIdType> : Form
    {
        private Panel _canvas;
        private readonly Engine<TWindowIdType> _engine;

        public abstract TWindowIdType Id { get; }

        protected Window(Engine<TWindowIdType> engine)
        {
            _engine = engine;
            InitializeComponent();
        }

        public void OnInitializeWindow(EventArgs e)
        {
            EventHandler handler = InitializeWindow;
            handler?.Invoke(this, e);
        }

        public abstract void RenderWindow(Graphics g);

        public abstract void UpdateWindow(int delta);

        public event EventHandler InitializeWindow;

        private void _canvas_Paint(object sender, PaintEventArgs e)
        {
            _engine.Start(_canvas.CreateGraphics());
        }

        private void InitializeComponent()
        {
            _canvas = new Panel();
            SuspendLayout();

            // 
            // _canvas
            // 
            _canvas.Dock = DockStyle.Fill;
            _canvas.Location = new Point(0, 0);
            _canvas.Name = "_canvas";
            _canvas.Size = new Size(800, 600);
            _canvas.TabIndex = 0;
            _canvas.Paint += _canvas_Paint;

            // 
            // Window
            // 
            ClientSize = new Size(800, 600);
            Controls.Add(_canvas);
            Name = "Window";
            ResumeLayout(false);
        }
    }
}
