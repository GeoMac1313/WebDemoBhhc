using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Web.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web.Controllers
{
    public class MaintenanceController : Controller
    {
        private readonly IHomeViewModelService _homeViewModelService;

        public MaintenanceController(IHomeViewModelService homeViewModelService)
        {
            _homeViewModelService = homeViewModelService;
        }

        // GET: Maintenance
        public ActionResult Index()
        {
            var items = _homeViewModelService.GetReasons(0);

            return View(items);


            //return View();
        }

        // GET: Maintenance/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Maintenance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maintenance/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Description,LastChangedBy")] Reason reason)
        {
            try
            {
                _homeViewModelService.AddReason(reason);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Maintenance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reason = _homeViewModelService.GetReasonById(id.GetValueOrDefault());
            return View(reason);
        }

        // POST: Maintenance/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost([Bind("Id,Description,LastChangedBy")] Reason reason)
        {
            try
            {

                if (reason.Id == 0)
                {
                    return NotFound();
                }

                var reasonToEdit = _homeViewModelService.GetReasonById(reason.Id);
                reasonToEdit.Description = reason.Description;
                reasonToEdit.LastChangedBy = reason.LastChangedBy;

                _homeViewModelService.UpdateReason(reasonToEdit);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Maintenance/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reason = _homeViewModelService.GetReasonById(id.GetValueOrDefault());
            if (reason.Id ==0)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(reason);
        }

        // POST: Maintenance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var reasonToDelete = _homeViewModelService.GetReasonById(id);

                _homeViewModelService.DeleteReason(reasonToDelete);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}