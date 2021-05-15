using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Models;
using OnlineShopping.Models.DTO;
using OnlineShopping.Models.Entity;

namespace OnlineShopping.Controllers
{
    [Route("dil")]
    [ApiController]
    public class DilController : Controller
    {
        private readonly ModelContext _context;

        public DilController(ModelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Dil> Get()
        {
            return _context.Diller.ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<Dil> GetById(int id)
        {
            var dil = _context.Diller.FirstOrDefault(p => p.Id == id);
            if(dil is null)
            {
                return Ok("Veri bulunamadı");
            }
            return dil;
        }

        [HttpPost]
        public ActionResult Post(DilDTO dilDTO)
        {
            var dil = new Dil { Ad = dilDTO.Ad };
            _context.Diller.Add(dil);
            _context.SaveChanges();
            return Ok("Veri ekleme işlemi başarılı");
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, DilDTO dilDTO)
        {
            var dil = _context.Diller.FirstOrDefault(p => p.Id == id);
            dil.Ad = dilDTO.Ad;
            _context.SaveChanges();
            return Ok("Veri güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var dil = _context.Diller.FirstOrDefault(p => p.Id == id);
            _context.Remove(dil);
            _context.SaveChanges();
            return Ok("Veri silme işlemi başarılı");
        }
    }
}