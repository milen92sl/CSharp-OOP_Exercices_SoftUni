﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IDriver> driverRepository;
        private readonly IRepository<ICar> carsRepository;
        private readonly IRepository<IRace> raceRepository;

        private const int MinParticipants = 3;
        public ChampionshipController()
        {
            this.driverRepository = new DriverRepository();
            this.carsRepository = new CarRepository();
            this.raceRepository = new RaceRepository();
        }
        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);
            this.driverRepository.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            type = type + "Car";

            ICar car = null;

            switch (type)
            {
                case nameof(MuscleCar):
                    car = new MuscleCar(model, horsePower);
                    break;
                case nameof(SportsCar):
                    car = new SportsCar(model, horsePower);
                    break;
            }

            this.carsRepository.Add(car);

            return string.Format(OutputMessages.CarCreated, type, model);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);

            this.raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = this.raceRepository.GetByName(raceName);
            IDriver driver = this.driverRepository.GetByName(driverName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);
            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = this.driverRepository.GetByName(driverName);
            ICar car = this.carsRepository.GetByName(carModel);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);
            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < MinParticipants)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, MinParticipants));
            }

            var winners = race.Drivers
                 .OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
                 .Take(3)
                 .ToArray();

            this.raceRepository.Remove(race);

            return string.Format(OutputMessages.DriverFirstPosition, winners[0].Name, race.Name) +
                   Environment.NewLine +
                   string.Format(OutputMessages.DriverSecondPosition, winners[1].Name, race.Name) +
                   Environment.NewLine +
                   string.Format(OutputMessages.DriverThirdPosition, winners[2].Name, race.Name);
        }
    }
}
