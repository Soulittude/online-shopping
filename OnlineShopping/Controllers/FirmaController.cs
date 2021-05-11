using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Models;
using OnlineShopping.Models.DTO;

namespace OnlineShopping.Controllers
{
    [Route("firma")]
    [ApiController]
    public class FirmaController : Controller
    {
        private readonly ModelContext _context;

        public FirmaController(ModelContext context)
        {
            _context = context;
        }

        //get wwww.site.com/firma
        [HttpGet]
        public IEnumerable<Firma> Get()
        {
            return _context.Firmalar.ToArray();
        }

        //get wwww.site.com/firma/5
        [HttpGet("{id}")]
        public ActionResult<Firma> GetById(int id)
        {
            var firma = _context.Firmalar.FirstOrDefault(p => p.Id == id);
            if(firma is null)
            {
                return Ok("Böyle bir veri yok");
            }
            return firma;
        }

        [HttpPost]
        public ActionResult Post(FirmaDTO firmaDTO)
        {
            var firma = new Firma { Ad = firmaDTO.Ad, Ulke = firmaDTO.Ulke, Website = firmaDTO.Website };
            _context.Firmalar.Add(firma);
            _context.SaveChanges();
            return Ok("BAŞARILI");
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, FirmaDTO firmaDTO)
        {
            var firma = _context.Firmalar.FirstOrDefault(p => p.Id == id); //degisecek obje
           /* if (firma is null)
            {
                firma = new Firma { AdSoyad = firmaDTO.AdSoyad, Id = id };
                _context.Firmalar.Add(firma);
                _context.SaveChanges();
                return CreatedAtAction("Get", new { id = id }, firma);
            }*/
            firma.Ad = firmaDTO.Ad;
            firma.Ulke = firmaDTO.Ulke;
            firma.Website = firmaDTO.Website;
            _context.SaveChanges();
            return Ok("BAŞARILI");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var firma = _context.Firmalar.FirstOrDefault(p => p.Id == id);
            _context.Remove(firma);
            _context.SaveChanges();
            return Ok("BAŞARILI");
        }
    }
}