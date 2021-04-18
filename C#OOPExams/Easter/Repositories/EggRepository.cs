using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private ICollection<IEgg> eggs;

        public EggRepository()
        {
            this.eggs = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => (IReadOnlyCollection<IEgg>)this.eggs;
        public void Add(IEgg model) => eggs.Add(model);

        public bool Remove(IEgg model) => eggs.Remove(model);

        public IEgg FindByName(string name) => this.eggs.First(x => x.Name == name);
    }
}
