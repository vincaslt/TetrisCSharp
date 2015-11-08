using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisCS.GameEngine
{
    public delegate void RegisterWindowsDelegate();

    public abstract class BasicGame<TWindowIdType>
    {
        protected Engine<TWindowIdType> Engine;

        protected BasicGame()
        {
            Engine = new Engine<TWindowIdType>();
        }

        public void Start(TWindowIdType entryWindowId, RegisterWindowsDelegate register)
        {
            register();
            Engine.InitializeWindows(entryWindowId);
            Engine.Stop();
        }
    }
}
