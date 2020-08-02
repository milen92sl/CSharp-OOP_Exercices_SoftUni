using INStock.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INStock
{
    public class TrackingSystem
    {
        private readonly IList<IProduct> products;

        public TrackingSystem(IList<IProduct>repo)
        {
            products = repo;
        }

        public int Count => products.Count;

        public void Add(IProduct product)
        {
            if (this.Contains(product))
            {
                throw new ArgumentException("Product already exists");
            }

            products.Add(product);
        }

        public IProduct this[int index]
        {
            get { return products[index]; }

            set { products[index] = value; }
        }

        public bool Contains(IProduct product)
        {
            return products.Any(p => p.Label == product.Label);
        }

        public IProduct Find(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("No such index");
            }

            return this[index - 1];
        }
    }
}
