using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Application.Interfaces
{
    public interface IBuscarPlanoContaUserCase
    {
        PlanoContaModel RetornarPlanoContaModel(int? id);
    }
}