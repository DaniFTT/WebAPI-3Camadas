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

                var query = data.ProdutoModel.AsQueryable();
                if (whereExpProd != null)
                {
                    query = query.Where(whereExpProd);
                }
                if(orderByExpProd != null)
                {
                    query = query.OrderBy(orderByExpProd);
                }
                if(orderByDescendingExpProd != null)
                {
                    query = query.OrderByDescending(orderByDescendingExpProd);
                }

                return await query.AsNoTracking().ToListAsync();
            }
        }
    }
}
