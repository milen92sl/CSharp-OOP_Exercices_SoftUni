using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly ICollection<IBunny> bunnies;

        public BunnyRepository()
        {
            this.bunnies = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models => (IReadOnlyCollection<IBunny>)this.bunnies;
        public void Add(IBunny model)
        {
            this.bunnies.Add(model);
        }

        public bool Remove(IBunny model)=> this.bunnies.Remove(model);

        public IBunny FindByName(string name) => this.bunnies.First(bn => bn.Name == name);
    }
}
