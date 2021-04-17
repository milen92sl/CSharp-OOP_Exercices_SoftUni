using System;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        private const int DriverNameMinLength = 5;
        public Driver(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullEmptyOrLessThan(
                    value,
                    DriverNameMinLength,
                    string.Format(ExceptionMessages.InvalidName, value, DriverNameMinLength));

                this.name = value;
            }

        }

        public ICar Car { get; private set; }
        public int NumberOfWins { get; private set; }

        public bool CanParticipate => this.Car != null;

        public void WinRace()
        {
            this.NumberOfWins += 1;
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }

            this.Car = car;
        }
    }
}
