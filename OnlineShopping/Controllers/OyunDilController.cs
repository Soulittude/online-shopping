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
    [Route("oyundil")]
    [ApiController]
    public class OyunDilController : Controller
    {
        private readonly ModelContext _context;

        public OyunDilController(ModelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<OyunDil> Get()
        {
            return _context.OyunDilleri.ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<OyunDil> GetById(int id)
        {
            var oyundil = _context.OyunDilleri.FirstOrDefault(p => p.Id == id);
            if (oyundil is null)
            {
                return Ok("Veri bulunamadı");
            }
            return oyundil;
        }

        [HttpPost]
        public ActionResult Post(OyunDilDTO oyundilDTO)
        {
            var oyundil = new OyunDil { OyunID = oyundilDTO.OyunID, DilID = oyundilDTO.DilID };
            _context.OyunDilleri.Add(oyundil);
            _context.SaveChanges();
            return Ok("Veri ekleme işlemi başarılı");
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, OyunDilDTO oyundilDTO)
        {
            var oyundil = _context.OyunDilleri.FirstOrDefault(p => p.Id == id);
            oyundil.OyunID = oyundilDTO.OyunID;
            oyundil.DilID = oyundilDTO.DilID;

            _context.SaveChanges();
            return Ok("Veri güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var oyundil = _context.OyunDilleri.FirstOrDefault(p => p.Id == id);
            _context.Remove(oyundil);
            _context.SaveChanges();
            return Ok("Veri silme işlemi başarılı");
        }

        [HttpGet("oyun/{id}")]
        public IEnumerable<OyunDil> GetByOyunId(int id)
        {
            var oyundil = _context.OyunDilleri.Where(p => p.OyunID == id).ToArray();
            return oyundil;
        }
    }
}