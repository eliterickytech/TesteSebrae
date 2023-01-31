using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSebrae.Domain.Entities;

namespace TesteSebrae.Domain.Interfaces
{
    public interface ICepRepository
    {
        Task<CepModel> GetCEPDataAsync();
    }
}
