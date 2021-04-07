using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Factories;
using Nop.Web.Framework.Components;

namespace Nop.Web.Components
{
    public class CategoryNavigationViewComponent : NopViewComponent
    {
        private readonly ICatalogModelFactory _catalogModelFactory;

        /* public CategoryNavigationViewComponent(ICatalogModelFactory catalogModelFactory)
        {
            _catalogModelFactory = catalogModelFactory;

        } */

     

        /* public async Task<IViewComponentResult> InvokeAsync(int currentCategoryId, int currentProductId)
         {
             var model = await _catalogModelFactory.PrepareCategoryNavigationModelAsync(currentCategoryId, currentProductId);
             return View(model);
         } */

        public async Task<IViewComponentResult> InvokeAsync()
        {
             

            var model_for_random = await _catalogModelFactory.PrepareHomepageCategoryModelsAsync();

            if (!model_for_random)
            {
             var currentCategoryId = model_for_random.Find("apparel").Id;
             var currentProductId = model_for_random.Find("apparel").Products.IndexOf();
                var model = await _catalogModelFactory.PrepareCategoryNavigationModelAsync(currentCategoryId, currentProductId);
                return View(model);

            }

            //var model = await _catalogModelFactory.PrepareCategoryNavigationModelAsync(currentCategoryId, currentProductId);
            return View(model_for_random);
        } 
    }
}
