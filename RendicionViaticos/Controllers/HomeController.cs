using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RendicionViaticos.Models;
using RendicionViaticos.Services.Unit;
using RendicionViaticos.ViewModels;
using System.Diagnostics;

namespace RendicionViaticos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            string codDigitador = "432";
            int page = 1;
            int size = 10;
            List<StatementHeaderVM> result = new List<StatementHeaderVM>();
            var StatementHeaders = this._unitOfWork.StatementHeaders.Get(e => e.COD_DIGITADOR.Equals(codDigitador))
                .OrderByDescending(e => e.EJERCICIO).ThenByDescending(e => e.CORRELATIVO).Skip((page - 1) * size).Take(size).ToList();
            result = this._mapper.Map<List<StatementHeaderVM>>(StatementHeaders);
            return View(result);
        }

        [HttpPost]
        public ActionResult Index(int page = 1, int size = 10)
        {
            string codDigitador = "432";
            List<StatementHeaderVM> result = new List<StatementHeaderVM>();
            var StatementHeaders = this._unitOfWork.StatementHeaders.Get(e => e.COD_DIGITADOR.Equals(codDigitador))
                .OrderByDescending(e => e.EJERCICIO).ThenByDescending(e => e.CORRELATIVO).Skip((page - 1) * size).Take(size).ToList();
            result = this._mapper.Map<List<StatementHeaderVM>>(StatementHeaders);
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}