
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Services.Interfaces
{
    public interface IPlanoContaService
    {
        List<PlanoContaModel> ListaPlanoContaModel();

        void CadastrarPlanoConta(PlanoContaModel input);

        void ExcluirPlanoConta(int id);

        PlanoContaModel RetornarPlanoContaModel(int? id);
    }
}