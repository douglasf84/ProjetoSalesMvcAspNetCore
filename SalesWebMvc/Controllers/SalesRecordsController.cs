using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Services;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {

        private readonly SalesRecordService _salesRecordeServices;
        private readonly SellerService _sellerService;

        public SalesRecordsController(SalesRecordService salesRecordeServices, SellerService sellerService)
        {
            _salesRecordeServices = salesRecordeServices;
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordeServices.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }


            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordeServices.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            var sellers = await _salesRecordeServices.FindAllAsync();
            var viewModel = new SalesRecordFormViewModel { Sellers = sellers };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SalesRecord salesRecord)
        {
            if (!ModelState.IsValid)
            {
                var sellers = await _salesRecordeServices.FindAllAsync();
                var viewModel = new SalesRecordFormViewModel { Sellers = sellers };
                return View(viewModel);
            }

            //salesRecord.Status = Enum.Parse<SaleStatus>(ViewData["StatusId"].ToString());
            salesRecord.Status = Enum.Parse<SaleStatus>(ViewData["SaleStatusId"].ToString());
            salesRecord.Date = DateTime.Now.Date;
            await _salesRecordeServices.InsertAsync(salesRecord);
            return RedirectToAction(nameof(Index));

        }

    }
}

