using System;
using System.Collections.Generic;
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
        private readonly Thread _renderThread;
        private readonly Thread _updateThread;

        public Engine()
        {
            _windows = new Dictionary<TWindowIdType, Window<TWindowIdType>>();
            _renderThread = new Thread(Render);
            _updateThread = new Thread(Update);
        }

        public void InitializeWindows(
            TWindowIdType entryWindow
        )
        {
            foreach (var window in _windows)
            {
                window.Value.OnInitializeWindow(new EventArgs());
            }

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
                _activeWindow.Close();
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
            _renderThread.Abort();
            _updateThread.Abort();
        }

        public void Start(Graphics g)
        {
            _renderThread.Start(g);
            _updateThread.Start();
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
            while (_activeWindow != null && _activeWindow.Visible)
            {
                executionBody();
            }
        }
    }
}
