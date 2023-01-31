using AutoMapper;
using TesteSebrae.Application.Interfaces;
using TesteSebrae.Application.Models;
using TesteSebrae.Domain.Interfaces;

namespace TesteSebrae.Application
{ 
    public class CepServices : ICepServices
    {
        private readonly ICepRepository _cepRepository;
        private readonly IMapper _mapper;
  
        public CepServices(ICepRepository cepRepository, IMapper mapper)
        {
            _cepRepository = cepRepository;
            _mapper = mapper;
        }

        public async Task<CepViewModel> GetCEPDataAsync()
        {
            var result = await _cepRepository.GetCEPDataAsync();

            var map = _mapper.Map<CepViewModel>(result);

            return map;
        }

    }
}