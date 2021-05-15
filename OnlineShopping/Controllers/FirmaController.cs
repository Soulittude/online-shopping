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

        [HttpGet]
        public IEnumerable<Firma> Get()
        {
            return _context.Firmalar.ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<Firma> GetById(int id)
        {
            var firma = _context.Firmalar.FirstOrDefault(p => p.Id == id);
            if(firma is null)
            {
                return Ok("Veri bulunamadı");
            }
            return firma;
        }

        [HttpPost]
        public ActionResult Post(FirmaDTO firmaDTO)
        {
            var firma = new Firma { Ad = firmaDTO.Ad, Ulke = firmaDTO.Ulke, Website = firmaDTO.Website };
            _context.Firmalar.Add(firma);
            _context.SaveChanges();
            return Ok("Veri ekleme işlemi başarılı");
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, FirmaDTO firmaDTO)
        {
            var firma = _context.Firmalar.FirstOrDefault(p => p.Id == id);
            firma.Ad = firmaDTO.Ad;
            firma.Ulke = firmaDTO.Ulke;
            firma.Website = firmaDTO.Website;
            _context.SaveChanges();
            return Ok("Veri güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var firma = _context.Firmalar.FirstOrDefault(p => p.Id == id);
            _context.Remove(firma);
            _context.SaveChanges();
            return Ok("Veri silme işlemi başarılı");
        }
    }
}