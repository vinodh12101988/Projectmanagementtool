using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Projectmanagementtool.Data;
using Projectmanagementtool.Models;

namespace Projectmanagementtool.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class productsController : Controller
    {
        private readonly ProjectDBContext _varprojectDBContext;
        public productsController(ProjectDBContext dbcontext) {
        this._varprojectDBContext = dbcontext;
        }

        [HttpGet]
        public async Task <IActionResult> GetAllProductsnew()
        {
            var allproduct = await _varprojectDBContext.ProductList.ToListAsync();
            return Ok(allproduct);
        }
        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Products table_products)
        
        {
            table_products.Id = Guid.NewGuid();

            await _varprojectDBContext.ProductList.AddAsync(table_products);

            await  _varprojectDBContext.SaveChangesAsync();

            return Ok(table_products);

        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await _varprojectDBContext.ProductList.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<ActionResult> updateProduct([FromRoute] Guid id, Products updateproducthtml)
        {
            var product = await _varprojectDBContext.ProductList.FindAsync(id);
            if (product == null) { return NotFound(); }

            product.Product_Name = updateproducthtml.Product_Name;
            product.Colour = updateproducthtml.Colour;
            product.Price = updateproducthtml.Price;
            product.Type = updateproducthtml.Type;

            await _varprojectDBContext.SaveChangesAsync(); return Ok(product);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var product = await _varprojectDBContext.ProductList.FindAsync(id);
            if (product == null) { return NotFound();}
            _varprojectDBContext.ProductList.Remove(product);
            await _varprojectDBContext.SaveChangesAsync(); return Ok(product);

        }
    }
}
