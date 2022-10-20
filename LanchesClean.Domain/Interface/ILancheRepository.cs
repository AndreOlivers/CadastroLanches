using LanchesClean.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanchesClean.Domain.Interface
{
    public interface ILancheRepository
    {
        Task<IEnumerable<Lanche>> GetLancheAsync();
        Task<Lanche> GetById(int? id);
        Task<Lanche> GetLancheCategoryAsync(int? id);

        Task<Lanche> Create(Lanche lanche);
        Task<Lanche> Update(Lanche lanche);
        Task<Lanche> Delete(Lanche lanche);
    }
}
