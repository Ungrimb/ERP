using ERP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ERP.Data
{
    public class CategoriaRepository : GenericRepository<Categoria>, ICategoriaRepository
    {

        public CategoriaRepository (ERPContext dbcontext) : base(dbcontext)
        {
        }
        public Task<Categoria> GetCategoriaById (long Id)
        {
            return GetAll().FirstOrDefaultAsync(x => x.Id == Id);
        }

    }
}
