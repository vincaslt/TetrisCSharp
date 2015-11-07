using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisCS.GameEngine
{
    //GAUTI GRAPHICS

    public abstract class Window<TWindowIdType> : Form
    {
        public abstract TWindowIdType Id { get; }

        public abstract void RenderState();

        public abstract void UpdateState();

        public virtual void InitializeState()
        {
            Console.WriteLine("Init");
        }

        public virtual void EnterState()
        {
            Console.WriteLine("Enter");
        }

        public virtual void LeaveState()
        {
            Console.WriteLine("Leave");
        }
    }
}
