
using myfinance_web_netcore.Application.Interfaces;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Services.Interfaces;

namespace myfinance_web_netcore.Application.BuscarPlanoContaUseCase
{
    public class BuscarPlanoContaUseCase : IBuscarPlanoContaUserCase
    {
        private readonly IPlanoContaService _planoContaService;

        public BuscarPlanoContaUseCase(IPlanoContaService planoContaService)
        {
            _planoContaService = planoContaService;
        }

        public PlanoContaModel RetornarPlanoContaModel(int? id)
        {
            return _planoContaService.RetornarPlanoContaModel(id);
        }
    }
}