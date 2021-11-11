using Business.Interfaces;
using Business.Interfaces.Services;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProduto _produto;

        public ProdutoService(IProduto produto)
        {
            _produto = produto;
        }

        public async Task<List<ProdutoModel>> ListarProdutosMaisComprados()
        {
            //var list = await ListarProdutos(p => p.Ativo);
            //return list.OrderBy(p => p.DataDeCriacao).Take(5).ToList();
            var list = await _produto.ListarProdutos(whereExpProd: prod => prod.Ativo, orderByDescendingExpProd: prod => prod.QuantidadeVendida);
            return list;
        }

        public async Task<List<ProdutoModel>> ListarProdutosMaisRecentes()
        {
            //var list = await ListarProdutos(whereExpProd: w => w.Ativo);
            //return list.OrderBy(p => p.DataDeCriacao).Take(5).ToList();
            var list = await _produto.ListarProdutos(whereExpProd: prod => prod.Ativo, orderByExpProd: prod => prod.DataDeCriacao);
            return list;
        }

        public async Task<List<ProdutoModel>> ListarProdutosInativos()
        {
            return await _produto.ListarProdutos(whereExpProd: prod => !prod.Ativo);
        }

        public async Task<List<ProdutoModel>> ListarProdutosAtivos()
        {
            return await _produto.ListarProdutos(whereExpProd: prod => prod.Ativo);
        }
    }
}
