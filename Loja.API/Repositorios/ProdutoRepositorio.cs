using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loja.API.Data;
using Loja.API.Entidades;
using MongoDB.Driver;

namespace Loja.API.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly ICatalogoContexto _context;
        
        public ProdutoRepositorio(ICatalogoContexto contexto)
        {
            _context = contexto;
        }


        public async Task CreateProduct(Produto product)
        {
            await _context.Produto.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Produto> filter = Builders<Produto>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context.Produto.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

      

        public async Task<IEnumerable<Produto>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Produto> filter = Builders<Produto>.Filter.Eq(p => p.Category, categoryName);

            return await _context.Produto.Find(filter).ToListAsync();
                }

        public async Task<Produto> GetProdut(string id)
        {
            return await _context.Produto.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Produto>> GetProduto()
        {
            return await _context.Produto.Find(p => true).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> GetProdutoByName(string name)
        {
            FilterDefinition<Produto> filter = Builders<Produto>.Filter.ElemMatch(p => p.Name, name);

          return  await  _context.Produto.Find(filter).ToListAsync();
        }

        public async Task<bool> UpdateProduct(Produto product)
        {
            var updateResult = await  _context.Produto.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
