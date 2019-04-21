using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Presentation.MVC.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Atestados.Presentation.MVC.Controllers
{
    public class ClinicaHospitalController : Controller
    {
        private readonly IClinicaHospitalAppServices _clinicaHospitalAppServices;

        public ClinicaHospitalController(IClinicaHospitalAppServices clinicaHospitalAppServices)
        {
            _clinicaHospitalAppServices = clinicaHospitalAppServices;
        }

        // GET: ClinicaHospital
        public ActionResult Index()
        {
            var clinicaHospitalViewModel = Mapper.Map<ICollection<ClinicaHospital>, ICollection<ClinicaHospitalViewModel>>
                (_clinicaHospitalAppServices.GetAll());
            return View(clinicaHospitalViewModel);
        }

        // GET: ClinicaHospital/Details/5
        public ActionResult Details(int id)
        {
            var clinicaHospitalViewModel = Mapper.Map<ClinicaHospital, ClinicaHospitalViewModel>
                (_clinicaHospitalAppServices.GetById(id));
            return View(clinicaHospitalViewModel);
        }

        // GET: ClinicaHospital/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClinicaHospital/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClinicaHospitalViewModel clinicaHospital)
        {
            if (ModelState.IsValid)
            {
                var clinicaHospitalDomain = Mapper.Map<ClinicaHospitalViewModel, ClinicaHospital>(clinicaHospital);
                _clinicaHospitalAppServices.Add(clinicaHospitalDomain);

                return RedirectToAction("Index");
            }

            return View(clinicaHospital);
        }

        // GET: ClinicaHospital/Edit/5
        public ActionResult Edit(int id)
        {
            var clinicaHospitalViewModel = Mapper.Map<ClinicaHospital, ClinicaHospitalViewModel>
                (_clinicaHospitalAppServices.GetById(id));
            return View(clinicaHospitalViewModel);
        }

        // POST: ClinicaHospital/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClinicaHospitalViewModel clinicaHospital)
        {
            if (ModelState.IsValid)
            {
                var clinicaHospitalDomain = Mapper.Map<ClinicaHospitalViewModel, ClinicaHospital>(clinicaHospital);
                _clinicaHospitalAppServices.Update(clinicaHospitalDomain);

                return RedirectToAction("Index");
            }

            return View(clinicaHospital);
        }

        // GET: ClinicaHospital/Delete/5
        public ActionResult Delete(int id)
        {
            var clinicaHospitalViewModel = Mapper.Map<ClinicaHospital, ClinicaHospitalViewModel>
                (_clinicaHospitalAppServices.GetById(id));
            return View(clinicaHospitalViewModel);
        }

        // POST: ClinicaHospital/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var clinicaHospital = _clinicaHospitalAppServices.GetById(id);
            _clinicaHospitalAppServices.Delete(clinicaHospital);

            return RedirectToAction("Index");
        }
    }
}
