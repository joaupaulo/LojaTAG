using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loja.API.Entidades;

namespace Loja.API.Repositorios
{
    public interface IProdutoRepositorio
    {
        Task<IEnumerable<Produto>> GetProduto();
        Task<Produto> GetProdut(string id);
        Task<IEnumerable<Produto>> GetProdutoByName(string name);
        Task<IEnumerable<Produto>> GetProductByCategory(string categoryName);
        Task CreateProduct(Produto product);
        Task<bool> UpdateProduct(Produto product);
        Task<bool> DeleteProduct(string id);
    }
}
