﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly IDictionary<string,IDriver> driverByName;

        public DriverRepository()
        {
            this.driverByName = new Dictionary<string,IDriver>();
        }
        public IDriver GetByName(string name)
        {
            return this.driverByName.GetByKeyOrDefault(name);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return this.driverByName.Values.ToList();
        }

        public void Add(IDriver model)
        {
            if (this.driverByName.ContainsKey(model.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, model.Name));
            }

            this.driverByName.Add(model.Name, model);
        }

        public bool Remove(IDriver model)
        {
            return this.driverByName.Remove(model.Name);
        }
    }
}
