using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSebrae.Application.Models;

namespace TesteSebrae.Application.Interfaces
{
    public interface ICepServices
    {
        Task<CepViewModel> GetCEPDataAsync();
    }
}
