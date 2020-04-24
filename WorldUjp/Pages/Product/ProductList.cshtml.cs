using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorldUjp.Pages.Product
{
    public class ProductListModel : PageModel
    {
        private readonly ITaxPayerRepository taxPayerService;

        public ProductListModel(ITaxPayerRepository taxPayerService)
        {
            this.taxPayerService = taxPayerService;
        }
        [TempData]
        public string Message { get; set; }

        public Core.TaxPayer TaxPayer { get; set; }
        public void OnGet(int id)
        {
            TaxPayer = taxPayerService.GetTaxPayer(id);
        }
    }
}