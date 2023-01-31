using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSebrae.Application.Models;

namespace TesteSebrae.Application.Interfaces
{
    public interface IContaServices
    {
        Task<bool> DeleteContaAsync(int Id);
        Task<int> InsertContaAsync(string conta);
        Task<List<ContaViewModel>> SelectContaAsync();
        Task<bool> UpdateContaAsync(string conta, int Id);
    }
}
