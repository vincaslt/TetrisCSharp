using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TetrisCS.GameEngine
{
    public class Engine<TWindowIdType>
    {
        private Dictionary<TWindowIdType, Window<TWindowIdType>> _windows;
        private Window<TWindowIdType> _activeWindow;

        public Engine()
        {
            _windows = new Dictionary<TWindowIdType, Window<TWindowIdType>>();
        }

        /**
        * Initializes all registered windows and enter the one specified, only has to be run once
        */
        public void InitializeWindows(
            TWindowIdType entryWindow
        )
        {
            foreach (var window in _windows)
            {
                window.Value.InitializeState();
            }

            _activeWindow = _windows[entryWindow];
            _windows[entryWindow].EnterState();
            Application.Run(_windows[entryWindow]);
        }

        public void RegisterWindow(Window<TWindowIdType> window)
        {
            _windows.Add(window.Id, window);
        }

        public void GoToWindow(TWindowIdType id)
        {
            if (_windows.ContainsKey(id))
            {
                _activeWindow.Close();
                _activeWindow.LeaveState();

                _activeWindow = _windows[id];
                _activeWindow.EnterState();
                _activeWindow.Show();
            }   
        }
    }
}
