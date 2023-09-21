using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RendicionViaticos.Models.Rendicion;
using RendicionViaticos.Services.Unit;
using RendicionViaticos.ViewModels;

namespace RendicionViaticos.Controllers
{
    public class PerDiemStatementController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PerDiemStatementController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }
        // GET: PerDiemStatementController
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

        [HttpGet, ActionName("crear-rendicion")]
        public ActionResult CreateStatement()
        {
            string codDigitador = "432";
            PerDiemStatementVM result = new PerDiemStatementVM();
            var statements = this._unitOfWork.StatementHeaders.Get(e => e.COD_DIGITADOR.Equals(codDigitador)).ToList();
            var years = statements.Select(e => new Year { EJERCICIO = e.EJERCICIO , EJERCICIO_NUM = Int32.Parse(e.EJERCICIO)}).Distinct().OrderByDescending(e => e.EJERCICIO_NUM).ToList();

            return View(result);
        }

        // GET: PerDiemStatementController/Details/5
        public ActionResult Statement([FromQuery] string exercise, [FromQuery] string nrp_cp)
        {
            PerDiemStatementVM result = new PerDiemStatementVM();
            StatementHeaderVM statementHeader = this._mapper.Map<List<StatementHeaderVM>>(this._unitOfWork.StatementHeaders.Get(e => e.EJERCICIO.Equals(exercise) && e.NRO_CP.Equals(nrp_cp))).FirstOrDefault();

            if (statementHeader == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                result.StatementHeader = statementHeader;
                var details = this._unitOfWork.StatementDetails.Get(e => e.EJERCICIO.Equals(statementHeader.EJERCICIO) && e.CORRELATIVO.Equals(statementHeader.CORRELATIVO));
                result.StatementDetails = this._mapper.Map<List<StatementDetailVM>>(details);
                return View(result);
            }
        }

        [HttpPost, ActionName("guardar-cabecera-rendicion")]
        public void SaveStatementHeader(StatementHeaderVM statementHeader)
        {
            var statementHeaderDB = this._mapper.Map<rendidos_cab>(statementHeader);
            this._unitOfWork.StatementHeaders.Add(statementHeaderDB);
            this._unitOfWork.Commit();
            //return View(statementHeader);
        }

        [HttpPost, ActionName("guardar-detalle-rendicion")]
        public void SaveStatementDetail(StatementDetailVM statementDetail)
        {
            var statementDetailDB = this._mapper.Map<rendidos_det>(statementDetail);
            this._unitOfWork.StatementDetails.Add(statementDetailDB);
            this._unitOfWork.Commit();
            //return View(statementHeader);
        }

        // GET: PerDiemStatementController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PerDiemStatementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PerDiemStatementController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PerDiemStatementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
