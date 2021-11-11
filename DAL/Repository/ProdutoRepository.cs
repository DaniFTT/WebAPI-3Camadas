using Business.Interfaces;
using Data.Config;
using Data.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ProdutoRepository : GenericRepository<ProdutoModel>, IProduto
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        public ProdutoRepository()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<ProdutoModel>> ListarProdutos(Expression<Func<ProdutoModel, bool>> whereExpProd = null, 
                                                             Expression<Func<ProdutoModel, object>> orderByExpProd = null, 
                                                             Expression<Func<ProdutoModel, object>> orderByDescendingExpProd = null)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.ProdutoModel
                    .Where(whereExpProd)
                    .OrderBy(orderByExpProd)
                    .ThenByDescending(orderByDescendingExpProd).AsNoTracking().ToListAsync();
            }
        }
    }
}
