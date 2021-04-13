using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private decimal totalIncome;

        private List<IBakedFood> bakedFoods = new List<IBakedFood>();
        private List<IDrink> drinks = new List<IDrink>();
        private List<ITable> tables = new List<ITable>();

        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type == "Tea")
            {
                this.drinks.Add(new Tea(name, portion, brand));
            }
            else if (type == "Water")
            {
                this.drinks.Add(new Water(name, portion, brand));
            }

            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {

            if (type == "Bread")
            {
                this.bakedFoods.Add(new Bread(name, price));
            }
            else if (type == "Cake")
            {
                this.bakedFoods.Add(new Cake(name, price));
            }

            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == "InsideTable")
            {
                this.tables.Add(new InsideTable(tableNumber, capacity));
            }

            else if (type == "OutsideTable")
            {
                this.tables.Add(new OutsideTable(tableNumber, capacity));
            }

            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var freeTable in tables.Where(x => x.IsReserved == false))
            {
                sb.AppendLine(freeTable.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var bill = table.GetBill() + table.Price;
            totalIncome += bill;
            table.Clear();

            return $"Table: {tableNumber}" + Environment.NewLine +
                $"Bill: {bill:f2}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            IDrink drink = drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);
            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber ,drinkName + " " + drinkBrand);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            IBakedFood food = bakedFoods.FirstOrDefault(x => x.Name == foodName);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (food == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);
            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            if (table == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            table.Reserve(numberOfPeople);
            return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
        }
    }
}