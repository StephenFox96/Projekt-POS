using System;
using System.Collections.Generic;
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
using System.Threading;
using Iot.Device.Bmxx80;
using Iot.Device.Bmxx80.PowerMode;




namespace POS_20210523_1
{
    /// Main class that operates on data acquired from the hardware devices, scales them and sends to the data base.
    class MainClass
    {

        static void Main(string[] args)
        {
         
            ///  DispatcherTimer setup
            DispatcherTimer Timer= new System.Windows.Threading.DispatcherTimer();
            DispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            DispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            DispatcherTimer.Start();

            /// Fragment used to create connection between BME sensor and the programm.
            var i2cSettings = new I2cConnectionSettings(1, Bme280.DefaultI2cAddress);
            using I2cDevice i2cDevice = I2cDevice.Create(i2cSettings);
            using var bme280 = new Bme280(i2cDevice);

            AcquireData Acquire = new AcquireData();

            double[] tablica = new double[2];
            tablica = Acquire.ReadBME();

            double [] tab = new double [2];

            double temperature = tablica[0];
            double preassure = tablica[1];
            double humidity = tablica[2];

            double COtwo = Acquire.ReadCOtwo();


            /// Alarm constant values.
            double TempALM_HH = 0;
            double TempALM_LL = 0;
            double Pres_ALM_HH = 0;
            double Pres_ALM_LL = 0;
            double Hum_ALM_HH = 0;
            double Hum_ALM_LL = 0;
            double COtwo_ALM_HH = 0;
            double COtwo_ALM_LL = 0;

            SetAlarmValues(TempALM_HH, TempALM_LL, Pres_ALM_HH, Pres_ALM_LL, Hum_ALM_HH, Hum_ALM_LL, COtwo_ALM_HH, COtwo_ALM_LL);

            ShowData(temperature, preassure, humidity, COtwo);
            ActivateAlarm(TempALM_HH, TempALM_LL, Pres_ALM_HH, Pres_ALM_LL, Hum_ALM_HH, Hum_ALM_LL, COtwo_ALM_HH, COtwo_ALM_LL, temperature, preassure, humidity, COtwo);

        }

        /// Method used to operate time value.
        public static void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            /// Updating the Label which displays the current second
            lblSeconds.Content = DateTime.Now.Second;

            /// Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
        }

        /// Method used to calculate time value.
        private void Timer_Tick(object sender, EventArgs e)
        {

        }
        /// Method used to bind data with HTML interface.     
       static void ShowData(double temperature, double preassure, double humidity, double COtwo)
        {
           
        }

        /// Method that allows user to set desired values of alarm tresholds for the temperature, humidity, preassure and CO two levels.
        static void SetAlarmValues(double TempALM_HH, double TempALM_LL, double Pres_ALM_HH, double Pres_ALM_LL, double Hum_ALM_HH, double Hum_ALM_LL, double COtwo_ALM_HH, double COtwo_ALM_LL)
        {

        }


        ///  Method that checks wether the measured values stay in between the set alarm tresholds. Method generates alarm every time the above is unfulfilled.
        /// @returns Array of alarms values
        /// @retval TRUE    alarm exists
        /// @retval FALSE   alarm is off
        static double[] ActivateAlarm(double TempALM_HH, double TempALM_LL, double Pres_ALM_HH, double Pres_ALM_LL, double Hum_ALM_HH, double Hum_ALM_LL, double COtwo_ALM_HH, double COtwo_ALM_LL, double temperature, double preassure, double humidity, double COtwo)
        {
            double[] ALMtab = new double[7];
            
            for (int i=0; i<ALMtab.Length; i++)
            {
                ALMtab[i] = 0;
            }

            while (true)
            {
                if (temperature > TempALM_HH)
                { ALMtab[0] = 1; }
                else ALMtab[0] = 0;

                if (temperature < TempALM_LL)
                { ALMtab[1] = 1; }
                else ALMtab[1] = 0;

                if (humidity > Hum_ALM_HH)
                { ALMtab[2] = 1; }
                else  ALMtab[2] = 0;

                if (humidity < Hum_ALM_LL)
                { ALMtab[3] = 1; }
                else ALMtab[3] = 0;

                if (preassure > Pres_ALM_HH)
                { ALMtab[4] = 1; }
                else ALMtab[4] = 0;

                if (preassure < Pres_ALM_LL)
                { ALMtab[5] = 1; }
                else ALMtab[5] = 0;

                if (COtwo > COtwo_ALM_HH)
                { ALMtab[6] = 1; }
                else ALMtab[6] = 0;

                if (COtwo < COtwo_ALM_LL)
                { ALMtab[7] = 1; }
                else ALMtab[7] = 0;

                return ALMtab;
            }
        }
    }
}
