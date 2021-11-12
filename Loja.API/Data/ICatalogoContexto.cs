using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loja.API.Entidades;
using MongoDB.Driver;

namespace Loja.API.Data
{
   public interface ICatalogoContexto
    {
        IMongoCollection<Produto> Produto {get; }
    }
}
