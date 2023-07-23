using myfinance_web_netcore.Application.Interfaces;
using myfinance_web_netcore.Services.Interfaces;

namespace myfinance_web_netcore.Application.ExcluirPlanoContaUseCase
{
    public class ExcluirPlanoContaUseCase : IExcluirPlanoContaUseCase
    {
        private readonly IPlanoContaService _planoContaService;

        public ExcluirPlanoContaUseCase(IPlanoContaService planoContaService)
        {
            _planoContaService = planoContaService;
        }
        public void ExcluirPlanoConta(int id)
        {
            _planoContaService.ExcluirPlanoConta(id);
        }
    }
}