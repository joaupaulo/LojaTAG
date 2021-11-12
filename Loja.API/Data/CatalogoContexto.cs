using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Loja.API.Entidades;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Loja.API.Data
{
    public class CatalogoContexto : ICatalogoContexto
    {

        public CatalogoContexto(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Produto = database.GetCollection<Produto>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
           
            CatalogoContextoSeed.SeedData(Produto);

        }

        public IMongoCollection<Produto> Produto { get; }
    }
}
