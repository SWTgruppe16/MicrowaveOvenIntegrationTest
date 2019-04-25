using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicrowaveOvenClasses.Interfaces
{
    public interface ITimer
    {
        TimeSpan TimeRemaining { get; }
        event EventHandler Expired;
        event EventHandler TimerTick;

        void Start(TimeSpan time);
        void Stop();
    }
}
