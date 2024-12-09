using MedicalAppointmentApp.Aplication.Contracts;
using MedicalAppointmentApp.Persistance.Models.Configuration;
using MedicalAppointmentApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using MedicalRecordModel = MedicalAppointmentApp.Persistance.Models.Configuration.MedicalRecordModel;

namespace MedicalAppointmentApp.Web.Controllers
{
    public class MedicalRecordsController : Controller
    {
        private readonly IMedicalRecordsService _medicalRecordService;

        public MedicalRecordsController(IMedicalRecordsService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _medicalRecordService.GetAll();
            if (result.IsSuccess)
            {
                var medicalRecords = (List<MedicalRecordModel>)result.Data;
                return View(medicalRecords);
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _medicalRecordService.GetById(id);
            if (result.IsSuccess)
            {
                var medicalRecord = (MedicalRecordModel)result.Data;
                return View(medicalRecord);
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MedicalRecordSaveDto medicalRecordSave)
        {
            try
            {
                var result = await _medicalRecordService.SaveAsync(medicalRecordSave);
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
            var result = await _medicalRecordService.GetById(id);
            if (result.IsSuccess)
            {
                var medicalRecord = (MedicalRecordModel)result.Data;
                return View(medicalRecord);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MedicalRecordUpdateDto medicalRecordUpdate)
        {
            try
            {
                var result = await _medicalRecordService.UpdateAsync(medicalRecordUpdate);
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
