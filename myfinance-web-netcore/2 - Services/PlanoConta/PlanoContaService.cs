
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Services.Interfaces;
using myfinance_web_netcore.Repository.Interfaces;

namespace myfinance_web_netcore.Services.PlanoContaService
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly IPlanoContaRepository _planoContaRepository;

        public PlanoContaService(IPlanoContaRepository planoContaRepository)
        {
            _planoContaRepository = planoContaRepository;
        }

        public void CadastrarPlanoConta(PlanoContaModel input)
        {
            var planoConta = new PlanoConta() {
                Id = input.Id,
                Descricao = input.Descricao,
                Tipo = input.Tipo
            };

            _planoContaRepository.Cadastrar(planoConta);
        }

        public void ExcluirPlanoConta(int id)
        {
            _planoContaRepository.Excluir(id);
        }

        public List<PlanoContaModel> ListaPlanoContaModel()
        {
            var lista = new List<PlanoContaModel>();
            var listaPlanoContas = _planoContaRepository.ListarRegistros();

            foreach (var item in listaPlanoContas)
            {
                var planoContaModel = new PlanoContaModel()
                {
                    Id = item.Id,
                    Descricao = item.Descricao,
                    Tipo = item.Tipo
                };

                lista.Add(planoContaModel);
            }

            return lista;
        }

        public PlanoContaModel RetornarPlanoContaModel(int? id)
        { 
            var planoContaDomain = _planoContaRepository.RetornarRegistro(id);

            return new PlanoContaModel(){
                Id = planoContaDomain.Id,
                Descricao = planoContaDomain.Descricao,
                Tipo = planoContaDomain.Tipo
            };
        }
    }
}