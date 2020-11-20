using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstAspNetCoreApplication.Data;
using MyFirstAspNetCoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public ProductsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet] //За да вземем данни използваме Get.
        public IEnumerable<Product> Get()
        {
            return db.Products.ToList();
        }

        [HttpGet("{id}")] //Ще работи само ако в параметъра му има подадено id.
        public ActionResult<Product> Get(int id)
        {
            var product = db.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost] //Когато искаме да вкараме данни правим Post.
        public async Task<ActionResult> Post(Product product)
        {
            await db.Products.AddAsync(product);
            await db.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = product.Id}, product); //Връща създадения продукт и линк към него.
        }

        [HttpPut] //Използваме го за редактиране на продукт.
        public async Task<ActionResult> Put(Product product)
        {
            db.Entry(product).State = EntityState.Modified; //Променяме състоянието на този продукт на "модифициран". Така ще се сравнят пропертитата на записания продукт и на този, който идва и на записания в базата ще му се присвоят новите стойности.
            await db.SaveChangesAsync(); //След това го записваме с промените.
            return NoContent(); //Накрая по правило се връща NoContent след редакцията.
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = db.Products.Find(id);
            
            if (product == null)
            {
                return NotFound();
            }

            db.Remove(product);
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
