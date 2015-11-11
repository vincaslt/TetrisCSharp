using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisCS.Utils
{
    public class Timer
    {
        private float _eventTime;
        private float _deltaStock;

        public Timer(int eventTime)
        {
            _eventTime = eventTime;
        }

        public void Update(int delta)
        {
            _deltaStock += delta;
            if (_deltaStock >= _eventTime)
            {
            }
        }

        public bool IsTimeComplete()
        {
            return _deltaStock >= _eventTime;
        }

        public void ResetTime()
        {
            _deltaStock = 0;
        }

        public void RestartTimer(int eventTime)
        {
            _eventTime = eventTime;
            ResetTime();
        }
    }
}
