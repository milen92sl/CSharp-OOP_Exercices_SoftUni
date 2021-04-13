namespace Bakery.Models.Tables
{
    using System;
    using System.Collections.Generic;
    using Bakery.Models.BakedFoods;
    using Bakery.Models.BakedFoods.Contracts;
    using Bakery.Models.Drinks;
    using Bakery.Models.Drinks.Contracts;
    using Bakery.Models.Tables.Contracts;
    using Bakery.Utilities.Messages;

    public abstract class Table : ITable
    {
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;
        

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
        }

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get
            {
                return this.numberOfPeople;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson {get; private set; }

        public bool IsReserved {get; private set; }

        public decimal Price
        {
            get => this.Price = NumberOfPeople * PricePerPerson;
            private set
            {
            }
        }

        public void Reserve(int numberOfPeople)
        {
            IsReserved = true;
            NumberOfPeople = numberOfPeople;
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            decimal bill = 0;

            foreach (var food in foodOrders)
            {
                bill += food.Price;
            }

            foreach (var drink in drinkOrders)
            {
                bill += drink.Price;
            }

            // bill += Price;
            return bill;
        }

        public void Clear()
        {
            foodOrders.Clear();
            drinkOrders.Clear();
            numberOfPeople = 0;
            IsReserved = false;
        }

        public string GetFreeTableInfo()
        {
            return $"Table: {this.TableNumber}\r\n" +
                   $"Type: {this.GetType().Name}\r\n" +
                   $"Capacity: {this.Capacity}\r\n" +
                   $"Price per Person: {this.PricePerPerson}";
        }
    }
}
