using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfinance_web_netcore.Application.Interfaces
{
    public interface IExcluirPlanoContaUseCase
    {
        void ExcluirPlanoConta(int id);
    }
}