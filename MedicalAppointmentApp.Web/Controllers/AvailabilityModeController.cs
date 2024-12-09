using MedicalAppointmentApp.Application.Contracts;
using MedicalAppointmentApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using AvailabilityModeSaveDto = MedicalAppointmentApp.Application.Contracts.AvailabilityModeSaveDto;
using AvailabilityModeUpdateDto = MedicalAppointmentApp.Application.Contracts.AvailabilityModeUpdateDto;

namespace MedicalAppointmentApp.Web.Controllers 
{
    public class AvailabilityModeController : Controller
    {
        private readonly IAvailabilityModesService _availabilityModeService;

        public AvailabilityModeController(IAvailabilityModesService availabilityModeService)
        {
            _availabilityModeService = availabilityModeService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _availabilityModeService.GetAll();
            if (result.IsSuccess)
            {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                var availabilityModes = (List<AvailabilityModeModel>)result.Data;
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                return View(availabilityModes);
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _availabilityModeService.GetById(id);
            if (result.IsSuccess)
            {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                var availabilityMode = (AvailabilityModeModel)result.Data;
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                return View(availabilityMode);
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AvailabilityModeSaveDto availabilityModeSave)
        {
            try
            {
                var result = await _availabilityModeService.SaveAsync(availabilityModeSave);
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
            var result = await _availabilityModeService.GetById(id);
            if (result.IsSuccess)
            {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                var availabilityMode = (AvailabilityModeModel)result.Data;
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                return View(availabilityMode);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AvailabilityModeUpdateDto availabilityModeUpdate)
        {
            try
            {
                var result = await _availabilityModeService.UpdateAsync(availabilityModeUpdate);
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
