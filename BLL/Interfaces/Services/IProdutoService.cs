using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface IProdutoService
    {
        Task<List<ProdutoModel>> ListarProdutosMaisComprados();
        Task<List<ProdutoModel>> ListarProdutosMaisRecentes();
        Task<List<ProdutoModel>> ListarProdutosInativos();
        Task<List<ProdutoModel>> ListarProdutosAtivos();
    }
}
