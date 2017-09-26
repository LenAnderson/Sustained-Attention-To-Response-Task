using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SART
{
    public class SustainedAttentionToResponseTask : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event EventHandler Finished;




        protected Thread SARTThread;
        protected bool Aborting = false;
        protected Stopwatch Watch = new Stopwatch();

        protected string _symbol;
        public string Symbol
        {
            get { return _symbol; }
            set
            {
                _symbol = value;
                OnPropertyChanged("Symbol");
            }
        }
        public List<LogEntry> Log { get; set; }




        public void Start()
        {
            ThreadStart starter = new ThreadStart(() =>
            {
                DoStart();
            });
            SARTThread = new Thread(starter);
            SARTThread.Start();
        }

        public void Abort()
        {
            Aborting = true;
        }

        protected void DoStart()
        {
            Log = new List<LogEntry>();
            Aborting = false;
            Watch.Reset();
            Random rand = new Random();

            for (int i = 5; i >= 0; i--)
            {
                Symbol = string.Format("Get ready...  {0}", i);
                Thread.Sleep(1000);
            }

            for (int i = 0; i < 225; i++)
            {
                if (Aborting)
                {
                    Watch.Stop();
                    return;
                }
                Symbol = rand.Next(1, 9).ToString();
                Log.Add(new LogEntry { Symbol = Symbol, Sequence = i * 2 });
                Watch.Restart();
                Thread.Sleep(250);
                long x = Watch.ElapsedMilliseconds;
                Symbol = "Ⓧ";
                Log.Add(new LogEntry { Symbol = Symbol, Sequence = i * 2 + 1 });
                Watch.Restart();
                Thread.Sleep(900);
            }
            Watch.Stop();
            Finished?.Invoke(this, new EventArgs());
        }




        public void SpacePressed()
        {
            if (Log.Count > 0)
            {
                Log[Log.Count - 1].Millis = Watch.ElapsedMilliseconds;
                Log[Log.Count - 1].PressedSpace++;
            }
        }
    }
}
