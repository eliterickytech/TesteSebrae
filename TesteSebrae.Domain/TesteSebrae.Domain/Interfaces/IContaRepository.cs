using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSebrae.Domain.Entities;

namespace TesteSebrae.Domain.Interfaces
{
    public interface IContaRepository
    {
        Task<int> InsertContaAsync(string conta);
        Task<IEnumerable<ContaModel>> SelectContaAsync();
        Task<bool> DeleteContaAsync(int id);
        Task<bool> UpdateContaAsync(string conta, int id);
    }
}
