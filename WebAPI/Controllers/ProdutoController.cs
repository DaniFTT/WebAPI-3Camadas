using Business.Interfaces;
using Business.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly IProduto _produto;
        public ProdutoController(IProdutoService produtoService, IProduto produto)
        {
            _produtoService = produtoService;
            _produto = produto;
        }

        [Produces("application/json")]
        [HttpPost("/api/AdicionarProduto")]
        public async Task<IActionResult> Add([FromBody] ProdutoModel produtoModel)
        {
            try
            {
                produtoModel.DataDeAlteracao = DateTime.Now;
                produtoModel.DataDeCriacao = DateTime.Now;

                await _produto.Add(produtoModel);
                return Ok("Produto Adicionado com successo!");
            }
            catch (Exception erro)
            {
                return BadRequest($"Ocorreu um erro ao tentar atualizar o produto\nErro:\n {erro.Message}");
            }
        }

        [Produces("application/json")]
        [HttpPut("/api/AtualizarProduto")]
        public async Task<IActionResult> Update([FromBody] ProdutoModel produtoModel)
        {
            try
            {
                var produtoAtual = await _produto.GetById(produtoModel.Id);
                produtoAtual.Nome = produtoModel.Nome;
                produtoAtual.Valor = produtoModel.Valor;
                produtoAtual.Ativo = produtoModel.Ativo;
                produtoAtual.DataDeAlteracao = DateTime.Now;

                await _produto.Update(produtoAtual);
                return Ok("Produto Atualizado com successo!");
            }
            catch (Exception erro)
            {
                return BadRequest($"Ocorreu um erro ao tentar atualizar o produto\nErro:\n {erro.Message}");
            }
        }

        [Produces("application/json")]
        [HttpDelete("/api/DeletarProduto")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                var produto = await _produto.GetById(id);

                if (produto != null)
                {
                    await _produto.Delete(produto);
                    return Ok("Produto excluido com sucesso!");
                }
                    
                return Ok("Produto não encontrado para ser execluido");
            }
            catch (Exception erro)
            {
                return BadRequest($"Ocorreu um erro ao tentar atualizar o produto\nErro:\n {erro.Message}");
            }
        }

        [Produces("application/json")]
        [HttpGet("/api/BuscarProdutoPorId")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            try
            {
                var produto = await _produto.GetById(id);

                if (produto != null)
                    return Json(produto);

                return Ok("Produto não encontrado");
            }
            catch (Exception erro)
            {
                return BadRequest($"Ocorreu um erro ao tentar encontrar o produto\nErro:\n {erro.Message}");
            }
        }

        [Produces("application/json")]
        [HttpGet("/api/ListarTodosProdutos")]
        public async Task<IActionResult> List()
        {
            try
            {
                var produtos = await _produto.List();

                if (produtos != null && produtos.Any())
                    return Json(produtos);

                return Ok("Nenhum produto encontrado");
            }
            catch (Exception erro)
            {
                return BadRequest($"Ocorreu um erro ao tentar encontrar os produtos\nErro:\n {erro.Message}");
            }
        }


        [Produces("application/json")]
        [HttpGet("/api/ListarProdutosAtivos")]
        public async Task<IActionResult> ListarProdutosAtivos()
        {
            try
            {
                var produtos = await _produtoService.ListarProdutosAtivos();

                if (produtos != null && produtos.Any())
                    return Json(produtos);

                return Ok("Nenhum produto encontrado");
            }
            catch (Exception erro)
            {
                return BadRequest($"Ocorreu um erro ao tentar encontrar os produtos\nErro:\n {erro.Message}");
            }
        }

        [Produces("application/json")]
        [HttpGet("/api/ListarProdutosInativos")]
        public async Task<IActionResult> ListarProdutosInativos()
        {
            try
            {
                var produtos = await _produtoService.ListarProdutosInativos();

                if (produtos != null && produtos.Any())
                    return Json(produtos);

                return Ok("Nenhum produto encontrado");
            }
            catch (Exception erro)
            {
                return BadRequest($"Ocorreu um erro ao tentar encontrar os produtos\nErro:\n {erro.Message}");
            }
        }


        [Produces("application/json")]
        [HttpGet("/api/ListarProdutosMaisRecentes")]
        public async Task<IActionResult> ListarProdutosMaisRecentes()
        {
            try
            {
                var produtos = await _produtoService.ListarProdutosMaisRecentes();

                if (produtos != null && produtos.Any())
                    return Json(produtos);

                return Ok("Nenhum produto encontrado");
            }
            catch (Exception erro)
            {
                return BadRequest($"Ocorreu um erro ao tentar encontrar os produtos\nErro:\n {erro.Message}");
            }
        }

        [Produces("application/json")]
        [HttpGet("/api/ListarProdutosMaisComprados")]
        public async Task<IActionResult> ListarProdutosMaisComprados()
        {
            try
            {
                var produtos = await _produtoService.ListarProdutosMaisComprados();

                if (produtos != null && produtos.Any())
                    return Json(produtos);

                return Ok("Nenhum produto encontrado");
            }
            catch (Exception erro)
            {
                return BadRequest($"Ocorreu um erro ao tentar encontrar os produtos\nErro:\n {erro.Message}");
            }
        }

        [Produces("application/json")]
        [HttpGet("/api/VenderProduto")]
        public async Task<IActionResult> VenderProduto([FromQuery] int idProduto, int quantidade)
        {
            try
            {
                var produtoAtual = await _produto.GetById(idProduto);

                if (produtoAtual != null)
                {
                    produtoAtual.QuantidadeVendida += quantidade;

                    await _produto.Update(produtoAtual);
                    return Ok("Produto Vendido com successo!");
                }


                return Ok("Produto não encontrado");
            }
            catch (Exception erro)
            {
                return BadRequest($"Ocorreu um erro ao tentar encontrar o produto\nErro:\n {erro.Message}");
            }
        }
    }
}
