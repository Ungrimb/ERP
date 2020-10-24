using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Models;
using ERP.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Web;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoryController : ControllerBase
    {

        GenericUnitOfWork _unitOfWork;
        
        public ActionResult Index()
        {
            _unitOfWork = new GenericUnitOfWork();
            var _categorias = _unitOfWork.GetRepoInstance<Categoria>().GetAll();
            return View (_categorias);
        }

    }
}
