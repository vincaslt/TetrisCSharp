using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisCS.GameEngine
{
    public delegate void RegisterWindowsDelegate();

    public abstract class BasicGame<TWindowIdType>
    {
        protected Engine<TWindowIdType> engine;

        public BasicGame()
        {
            engine = new Engine<TWindowIdType>();
        }

        public void Start(TWindowIdType entryWindowId, RegisterWindowsDelegate register)
        {
            register();
            engine.InitializeWindows(entryWindowId);
        }
    }
}
