using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Data;
using System.Threading;
using System.Diagnostics;
using System.Windows;
using System.Device.I2c;
using Iot.Device.Bmxx80;
using Iot.Device.Bmxx80.PowerMode;

namespace POS_20210523_1
{ 
        /// Class that uses different methods to acquire data from multiple sensors
    class AcquireData
    {
        /// Method acquires raw data from the controller, changes them to a properly scaled temperature, humidity and preassure value, then passes them to the array.
        /// @returns Scaled values of temperature, humidity and preassure.
        public double[]  ReadBME()
        {
            double [] tab = new double [2];
            int measurementTime = bme280.GetMeasurementDuration();

            while (true)
            {
                bme280.SetPowerMode(Bmx280PowerMode.Forced);
                Thread.Sleep(measurementTime);

                double tempval = bme280.TryReadTemperature(out var tempValue);
                double preval = bme280.TryReadPressure(out var preValue);
                double humval = bme280.TryReadHumidity(out var humValue);

                
                tab[0] = tempval;
                tab[1] = preval;
                tab[2] = humval;


                Thread.Sleep(1000);                
                return tab;

            }
           
        }
        /// Method that connects with CO two level sensor and saves value, then scales it to a proper value and returns.
        /// @returns Scaled value of CO two.
        public double ReadCOtwo()
        {
            return 0;
        }
      
      
    }

}

