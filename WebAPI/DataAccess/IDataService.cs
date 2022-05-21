using System;
using Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DataAccess
{
    public interface IDataService
    {
        // Child methods
        List<Child> GetChildren();

        Task<Child> AddChildAsync(Child c);

        // Toy methods

        List<Toy> GetToys();

        Task<Toy> AddToyAsync(Toy t);

        Task RemoveToyAsync(string Name);

    }
}
