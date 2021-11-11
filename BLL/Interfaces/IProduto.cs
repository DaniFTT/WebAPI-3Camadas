using Business.Interfaces.Generics;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IProduto : IGeneric<ProdutoModel>
    {
        Task<List<ProdutoModel>> ListarProdutos(Expression<Func<ProdutoModel, bool>> whereExpProd = null,
                                                Expression<Func<ProdutoModel, object>> orderByExpProd = null,
                                                Expression<Func<ProdutoModel, object>> orderByDescendingExpProd = null);
    }
}
