using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteSebrae.Domain.Entities
{
    public class ContaModel
    {
        public int Id { get; set; }

        public string Conta { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
