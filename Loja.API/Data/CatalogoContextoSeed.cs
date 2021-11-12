using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loja.API.Entidades;
using MongoDB.Driver;

namespace Loja.API.Data
{
    public class CatalogoContextoSeed
    {
        public static void SeedData(IMongoCollection<Produto> productCollection)
        {
            bool existeProduto = productCollection.Find(x => true).Any();

            if(!existeProduto)
            {
                productCollection.InsertManyAsync(GetMyProduct());
            }
        }

        private static IEnumerable<Produto> GetMyProduct()
        {
            return new List<Produto>()
            {
                new Produto()
                {
                     Id = "618e47622a1a7558fdc8e5ec",
                     Name = "Camisa OAKLEY MOD",
                     Category = "Camisas",
                     Descrption = "Azul Listrada",
                     Price = 29,
                     Amount = 40

                } ,
                 new Produto()
                {
                     Id = "618e47622a1a7558fdc8e5ec",
                     Name = "Regata OAKLEY MOD",
                     Category = "Regata",
                     Descrption = "Vermelho Listrada",
                     Price = 29,
                     Amount = 40

                }
            };
        }
    }
}
