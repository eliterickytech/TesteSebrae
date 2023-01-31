using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSebrae.Application.Interfaces;
using TesteSebrae.Application.Models;
using TesteSebrae.Domain.Entities;
using TesteSebrae.Domain.Interfaces;

namespace TesteSebrae.Application
{
    public class ContaServices : IContaServices
    {
        private readonly IContaRepository _contaRepository;
        private readonly IMapper _mapper;

        public ContaServices(IContaRepository contaRepository, IMapper mapper)
        {
            _contaRepository = contaRepository;
            _mapper = mapper;
        }

        public async Task<int> InsertContaAsync(string conta) => await _contaRepository.InsertContaAsync(conta);

        public async Task<bool> UpdateContaAsync(string conta, int id) => await _contaRepository.UpdateContaAsync(conta, id);

        public async Task<bool> DeleteContaAsync(int Id) => await _contaRepository.DeleteContaAsync(Id);

        public async Task<List<ContaViewModel>> SelectContaAsync()
        {
            var result = await _contaRepository.SelectContaAsync();

            return _mapper.Map<List<ContaViewModel>>(result);
        }
    }
}
