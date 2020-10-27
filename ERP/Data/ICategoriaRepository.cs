using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Data
{
    public interface ICategoriaRepository : IGenericRepository<Categoria>
    {
        Task<Categoria> GetCategoriaById (long Id);
    }
}
