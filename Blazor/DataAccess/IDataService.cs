using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.DataAccess
{
    interface IDataService
    {
        Task<IList<Child>> GetChildrenAsync();
        Task<IList<Toy>> GetToysAsync();

        public Task RemoveToyAsync(string Name);

        public Task CreateChildAsync(Child c);

        public Task CreateToyAsync(Toy t);
    }
}
