using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Presentation.MVC.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Atestados.Presentation.MVC.Controllers
{
    public class AtestadoController : Controller
    {
        private readonly IAtestadoAppServices _atestadoAppServices;
        private readonly IColaboradorAppServices _colaboradorAppServices;
        private readonly ICidAppServices _cidAppServices;
        private readonly IClinicaHospitalAppServices _clinicaHospitalAppServices;

        public AtestadoController(
            IAtestadoAppServices atestadoAppServices,
            IColaboradorAppServices colaboradorAppServices,
            ICidAppServices cidAppServices,
            IClinicaHospitalAppServices clinicaHospitalAppServices)
        {
            _atestadoAppServices = atestadoAppServices;
            _colaboradorAppServices = colaboradorAppServices;
            _cidAppServices = cidAppServices;
            _clinicaHospitalAppServices = clinicaHospitalAppServices;
        }

        // GET: Atestado
        public ActionResult Index()
        {
            var atestadoViewModel = Mapper.Map<ICollection<Atestado>, ICollection<AtestadoViewModel>>
                (_atestadoAppServices.GetAll());
            return View(atestadoViewModel);
        }

        // GET: Atestado/Details/5
        public ActionResult Details(int id)
        {
            var atestadoViewModel = Mapper.Map<Atestado, AtestadoViewModel>
                (_atestadoAppServices.GetById(id));
            return View(atestadoViewModel);
        }

        // GET: Atestado/Create
        public ActionResult Create()
        {
            ViewBag.ColaboradorId =
                new SelectList(_colaboradorAppServices.GetAll(), "ColaboradorId", "Nome");
            ViewBag.CidId =
                new SelectList(_cidAppServices.GetAll(), "CidId", "Codigo");
            ViewBag.ClinicaHospitalId =
                new SelectList(_clinicaHospitalAppServices.GetAll(), "ClinicaHospitalId", "Nome");

            return View();
        }

        // POST: Atestado/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AtestadoViewModel atestado)
        {
            if (ModelState.IsValid)
            {
                var atestadoDomain = Mapper.Map<AtestadoViewModel, Atestado>(atestado);
                _atestadoAppServices.Add(atestadoDomain);

                return RedirectToAction("Index");
            }

            return View(atestado);
        }

        // GET: Atestado/Edit/5
        public ActionResult Edit(int id)
        {
            var atestadoViewModel = Mapper.Map<Atestado, AtestadoViewModel>
                (_atestadoAppServices.GetById(id));

            ViewBag.ColaboradorId =
                new SelectList(_colaboradorAppServices.GetAll(), "ColaboradorId", "Nome", atestadoViewModel.ColaboradorId);
            ViewBag.CidId =
                new SelectList(_cidAppServices.GetAll(), "CidId", "Codigo", atestadoViewModel.CidId);
            ViewBag.ClinicaHospitalId =
                new SelectList(_clinicaHospitalAppServices.GetAll(), "ClinicaHospitalId", "Nome", atestadoViewModel.ClinicaHospitalId);

            return View(atestadoViewModel);
        }

        // POST: Atestado/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AtestadoViewModel atestado)
        {
            if (ModelState.IsValid)
            {
                var atestadoDomain = Mapper.Map<AtestadoViewModel, Atestado>(atestado);
                _atestadoAppServices.Update(atestadoDomain);

                return RedirectToAction("Index");
            }

            return View(atestado);
        }

        // GET: Atestado/Delete/5
        public ActionResult Delete(int id)
        {
            var atestadoViewModel = Mapper.Map<Atestado, AtestadoViewModel>
                (_atestadoAppServices.GetById(id));
            return View(atestadoViewModel);
        }

        // POST: Atestado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var atestado = _atestadoAppServices.GetById(id);
            _atestadoAppServices.Delete(atestado);

            return RedirectToAction("Index");
        }
    }
}
