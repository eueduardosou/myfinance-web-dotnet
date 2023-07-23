using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Application.Interfaces;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{   
    [Route("[controller]")]
    public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;
        private readonly MyFinanceDbContext _myFinanceDbContext;
        private readonly IObterPlanoContaUseCase _obterPlanoContaUseCase;
        private readonly ICadastrarPlanoContaUseCase _cadastrarPlanoContaUseCase;
        private readonly IExcluirPlanoContaUseCase _excluirPlanoContaUseCase;
        private readonly IBuscarPlanoContaUserCase _buscarPlanoContaUserCase;

        public PlanoContaController(
            ILogger<PlanoContaController> logger,
            MyFinanceDbContext myFinanceDbContext,
            IObterPlanoContaUseCase obterPlanoContaUseCase,
            ICadastrarPlanoContaUseCase cadastrarPlanoContaUseCase,
            IExcluirPlanoContaUseCase excluirPlanoContaUseCase,
            IBuscarPlanoContaUserCase buscarPlanoContaUserCase)
        {
            _logger = logger;
            _myFinanceDbContext = myFinanceDbContext;
            _obterPlanoContaUseCase = obterPlanoContaUseCase;
            _cadastrarPlanoContaUseCase = cadastrarPlanoContaUseCase;
            _excluirPlanoContaUseCase = excluirPlanoContaUseCase;
            _buscarPlanoContaUserCase = buscarPlanoContaUserCase;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.ListaPlanoContas = _obterPlanoContaUseCase.GetListaPlanoContaModel();
            return View();
        }

        [HttpGet]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(int id)
        {
            var planoConta = _buscarPlanoContaUserCase.RetornarPlanoContaModel(id);
            return View(planoConta);

            // var planoConta = new PlanoContaModel(); 

            // if (id != null)
            // {
            //     var planoContaDomain = _myFinanceDbContext.PlanoConta.Where(x => x.Id == id).FirstOrDefault();

            //     planoConta.Id = planoContaDomain.Id;
            //     planoConta.Descricao = planoContaDomain.Descricao;
            //     planoConta.Tipo = planoContaDomain.Tipo;
            // }
            // return View(planoConta);
        }

        [HttpPost]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(PlanoContaModel input)
        {
            _cadastrarPlanoContaUseCase.CadastrarPlanoConta(input);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            _excluirPlanoContaUseCase.ExcluirPlanoConta(id);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        } 
    }
}