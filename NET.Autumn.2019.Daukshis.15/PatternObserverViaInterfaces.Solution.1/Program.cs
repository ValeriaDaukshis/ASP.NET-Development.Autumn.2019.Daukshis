using System;
using System.Collections.Generic;

namespace PatternObserverViaInterfaces.Solution._1
{
    /// <summary>
    /// Program.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Thermostat thermostat = new Thermostat();
            Heater heater = new Heater(30);
            Cooler cooler = new Cooler(40);
            
            thermostat.Register(heater);
            thermostat.Register(cooler);

            thermostat.EmulateTemperatureChange();
            thermostat.EmulateTemperatureChange();
            
            thermostat.Unregister(cooler);
            thermostat.EmulateTemperatureChange();
        }
    }

    /// <summary>
    /// IObserver.
    /// </summary>
    public interface IObserver
    {
        void Update(IObservable sender, TemperatureEventArgs eventArgs);
    }

    /// <summary>
    /// IObservable.
    /// </summary>
    public interface IObservable
    {
        void Register(IObserver observer);
        void Unregister(IObserver observer);
        void Notify();
    }

    /// <summary>
    /// EventArgs.
    /// </summary>
    //базовый класс, предоставляющий дополнительную информацию о событии
    // для событий не предоставляющих дополнительную информацию свойство Empty
    public class EventArgs
    {
        public static readonly EventArgs Empty;
    }

    /// <summary>
    /// TemperatureEventArgs
    /// </summary>
    // класс, предоставляющий дополнительную информацию о событии изменения температуры
    public class TemperatureEventArgs : EventArgs
    {
        public int NewTemperature { get; private set; }
        public int OldTemperature { get; private set; }
        public TemperatureEventArgs(int oldTemperature, int newTemperature)
        {
            NewTemperature = newTemperature;
            OldTemperature = oldTemperature;
        }
    }

    /// <summary>
    /// Cooler
    /// </summary>
    /// <seealso cref="PatternObserverViaInterfaces.Solution._1.IObserver" />
    public class Cooler : IObserver
    {
        public Cooler(int temperature) => Temperature = temperature;

        public int Temperature { get; private set; }

        /// <summary>
        /// Updates the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="info">The <see cref="TemperatureEventArgs"/> instance containing the event data.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Update(IObservable sender, TemperatureEventArgs info)
        {
            if (info is null)
            {
                throw new ArgumentNullException();
            }
            
            if (info.NewTemperature != info.OldTemperature)
            {
                Console.WriteLine($"Cooler: On. Changed {Math.Abs(info.NewTemperature - info.OldTemperature)}");
            }
            else
            {
                Console.WriteLine($"Cooler: Off.");

            }
        }
    }

    /// <summary>
    /// Heater
    /// </summary>
    /// <seealso cref="PatternObserverViaInterfaces.Solution._1.IObserver" />
    public class Heater : IObserver
    {
        public Heater(int temperature) => Temperature = temperature;

        public int Temperature { get; private set; }

        /// <summary>
        /// Updates the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="info">The <see cref="TemperatureEventArgs"/> instance containing the event data.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Update(IObservable sender, TemperatureEventArgs info)
        {
            if (info is null)
            {
                throw new ArgumentNullException();
            }
            
            if (info.NewTemperature != info.OldTemperature)
            {
                Console.WriteLine($"Heater: On. Changed {Math.Abs(info.NewTemperature - info.OldTemperature)}");
            }
            else
            {
                Console.WriteLine($"Heater: Off.");
            }
        }
    }

    /// <summary>
    /// Thermostat
    /// </summary>
    /// <seealso cref="PatternObserverViaInterfaces.Solution._1.IObservable" />
    public class Thermostat: IObservable
    {
        private List<IObserver> _observersList;

        /// <summary>
        /// Initializes a new instance of the <see cref="Thermostat"/> class.
        /// </summary>
        public Thermostat()
        {
            _observersList = new List<IObserver>();
            currentTemperature = 5;
            previousTemperature = currentTemperature;
        }

        /// <summary>
        /// Registers the specified observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public void Register(IObserver observer)
        {
            _observersList.Add(observer);
        }

        /// <summary>
        /// Unregisters the specified observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public void Unregister(IObserver observer)
        {
            _observersList.Remove(observer);
        }

        /// <summary>
        /// Notifies this instance.
        /// </summary>
        public void Notify()
        {
            foreach (var obj in _observersList)
            {
                obj.Update(this, new TemperatureEventArgs(currentTemperature, previousTemperature));
            }
        }
        
        private int currentTemperature;
        private int previousTemperature;

        private Random random = new Random(Environment.TickCount);

        public int CurrentTemperature
        {
            get => currentTemperature;
            private set
            {
                previousTemperature = value;
                if (value != currentTemperature)
                {
                    Notify();
                }
            }
        }

        /// <summary>
        /// Emulates the temperature change.
        /// </summary>
        public void EmulateTemperatureChange()
        {
            this.CurrentTemperature = random.Next(0, 100);
        }
    }
}