using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Presentation.MVC.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Atestados.Presentation.MVC.Controllers
{
    public class CidController : Controller
    {
        private readonly ICidAppServices _cidAppServices;

        public CidController(ICidAppServices cidAppServices)
        {
            _cidAppServices = cidAppServices;
        }

        // GET: Cid
        public ActionResult Index()
        {
            var cidViewModel = Mapper.Map<ICollection<Cid>, ICollection<CidViewModel>>
                (_cidAppServices.GetAll());
            return View(cidViewModel);
        }

        // GET: Cid/Details/5
        public ActionResult Details(int id)
        {
            var cidViewModel = Mapper.Map<Cid, CidViewModel>
                (_cidAppServices.GetById(id));
            return View(cidViewModel);
        }

        // GET: Cid/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cid/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CidViewModel cid)
        {
            if (ModelState.IsValid)
            {
                var cidDomain = Mapper.Map<CidViewModel, Cid>(cid);
                _cidAppServices.Add(cidDomain);

                return RedirectToAction("Index");
            }

            return View(cid);
        }

        // GET: Cid/Edit/5
        public ActionResult Edit(int id)
        {
            var cidViewModel = Mapper.Map<Cid, CidViewModel>
                (_cidAppServices.GetById(id));
            return View(cidViewModel);
        }

        // POST: Cid/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CidViewModel cid)
        {
            if (ModelState.IsValid)
            {
                var cidDomain = Mapper.Map<CidViewModel, Cid>(cid);
                _cidAppServices.Update(cidDomain);

                return RedirectToAction("Index");
            }

            return View(cid);
        }

        // GET: Cid/Delete/5
        public ActionResult Delete(int id)
        {
            var cidViewModel = Mapper.Map<Cid, CidViewModel>
                (_cidAppServices.GetById(id));
            return View(cidViewModel);
        }

        // POST: Cid/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cid = _cidAppServices.GetById(id);
            _cidAppServices.Delete(cid);

            return RedirectToAction("Index");
        }
    }
}
