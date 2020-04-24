using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WorldUjp.Pages.Product
{
    public class CreateProductModel : PageModel
    {
        private readonly ITaxPayerRepository taxPayerService;
        private readonly IDDVRepository ddvService;
        private readonly IProductService productService;

        public CreateProductModel(ITaxPayerRepository taxPayerService, IDDVRepository ddvService, IProductService productService)
        {
            this.taxPayerService = taxPayerService;
            this.ddvService = ddvService;
            this.productService = productService;
        }
        [BindProperty]
        public Core.TaxPayer TaxPayer { get; set; }
        [BindProperty]
        public Core.Product Product { get; set; }
        [TempData]
        public string Message { get; set; }
        public IEnumerable<SelectListItem> SelectDDV { get; set; }
        public IActionResult OnGet(int id)
        {
            TaxPayer = taxPayerService.Get(id);
            SelectDDV = ddvService.GetAll().Select(d => new SelectListItem
            {
                Text = d.Tax.ToString(),
                Value = d.Id.ToString()
            });

            Product = new Core.Product();


            return Page();
        }

        public IActionResult OnPost()
        {
            var temp = taxPayerService.GetTaxPayer(TaxPayer.Id); // Mi se javuvase problem, koga klikam na Save a validacijata 
                                                                 // ne pominuva, pri renderiranje mi se gubea F_Name i L_Name na kupuvacot. 
                                                                 // So ova mi se reshava toj problem.
            if (ModelState.IsValid)
            {
                Product.TaxPayerId = TaxPayer.Id;
                Product = productService.CreateProduct(Product);

                TaxPayer.Products.Add(Product);
                productService.Commit();

                TempData["Message"] = "New Product Added to list !";

                return RedirectToPage("ProductList", new { id = TaxPayer.Id });
                
            }


            SelectDDV = ddvService.GetAll().Select(d => new SelectListItem
            {
                Text = d.Tax.ToString(),
                Value = d.Id.ToString()
            });
            TaxPayer = temp;
            return Page();
        }
    }
}