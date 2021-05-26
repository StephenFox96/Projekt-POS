using System;
using System.Collections.Generic;
using System.Text;

namespace POS_20210523_1
{
    class DispatcherTimer
    {
        /// Occurs when the timer interval has elapsed.
        internal static EventHandler Tick;

        /// Gets or sets the period of time between timer ticks.
        public static TimeSpan Interval { get; internal set; }

        /// Method that starts the DispatcherTimer.
        public static void Start()
        {
            throw new NotImplementedException();
        }
    }
}
