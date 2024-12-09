using MedicalAppointmentApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentApp.Web.Controllers
{
    public class SpecialtiesController : Controller
    {
        private readonly ISpecialtyService _specialtyService;

        public SpecialtiesController(ISpecialtyService specialtyService)
        {
            _specialtyService = specialtyService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _specialtyService.GetAll();
            if (result.IsSuccess)
            {
                var specialtiesModel = (List<SpecialtyModel>)result.Data;
                return View(specialtiesModel);
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _specialtyService.GetById(id);
            if (result.IsSuccess)
            {
                var specialtyModel = (SpecialtyModel)result.Data;
                return View(specialtyModel);
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialtySaveDto specialtySave)
        {
            try
            {
                var result = await _specialtyService.SaveAsync(specialtySave);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Message = result.Message;
                return View();
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _specialtyService.GetById(id);
            if (result.IsSuccess)
            {
                var specialtyModel = (SpecialtyModel)result.Data;
                return View(specialtyModel);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpecialtyUpdateDto specialtyUpdate)
        {
            try
            {
                var result = await _specialtyService.UpdateAsync(specialtyUpdate);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Message = result.Message;
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
