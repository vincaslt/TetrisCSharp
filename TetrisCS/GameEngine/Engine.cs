using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace TetrisCS.GameEngine
{
    public delegate void ExecuteThreadDelegate();

    public class Engine<TWindowIdType>
    {
        private Dictionary<TWindowIdType, Window<TWindowIdType>> _windows;
        private Window<TWindowIdType> _activeWindow;
        private Thread _renderThread;
        private Thread _updateThread;
        private bool _isRunning;

        public Engine()
        {
            _windows = new Dictionary<TWindowIdType, Window<TWindowIdType>>();
            InitThreads();
        }

        public void InitializeWindows(
            TWindowIdType entryWindow
        )
        {
            foreach (var window in _windows)
            {
                window.Value.OnInitializeWindow(new EventArgs());
            }

            new Thread(ExitListener).Start();

            GoToWindow(entryWindow);
        }

        public void RegisterWindow(Window<TWindowIdType> window)
        {
            _windows.Add(window.Id, window);
        }

        public void GoToWindow(TWindowIdType id)
        {
            if (!_windows.ContainsKey(id)) return;

            var initialize = true;
            if (_activeWindow != null)
            {
                Stop();
                _activeWindow.Hide();
                initialize = false;
            }

            _activeWindow = _windows[id];

            if (initialize)
            {
                Application.Run(_activeWindow);
            }  
            else
                _activeWindow.Show();
        }

        public void Stop()
        {
            _isRunning = false;
        }

        private void InitThreads()
        {
            _renderThread = new Thread(Render);
            _updateThread = new Thread(Update);
        }

        public void Start(Graphics g)
        {
            if (!_isRunning && !_renderThread.IsAlive && !_updateThread.IsAlive)
            {
                InitThreads();
                _renderThread.Start(g);
                _updateThread.Start();
            }
            _isRunning = true;
        }

        private void Render(object g)
        {
            ExecuteThread(delegate
            {
                _activeWindow.RenderWindow((Graphics)g);
            });
        }

        private void Update()
        {
            int startTime, lastTime = Environment.TickCount;

            ExecuteThread(delegate
            {
                startTime = Environment.TickCount;
                _activeWindow.UpdateWindow(startTime - lastTime);
                lastTime = startTime;
            });
        }

        private void ExecuteThread(ExecuteThreadDelegate executionBody)
        {
            while (_activeWindow != null && _activeWindow.Visible && _isRunning)
            {
                executionBody();
            }
        }

        private void ExitListener()
        {
            while (!_isRunning || _windows.Values.Any(w => w.Visible)) { }
            Application.Exit();
        }
    }
}
