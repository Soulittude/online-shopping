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

        //get wwww.site.com/OyunDil
        [HttpGet]
        public IEnumerable<OyunDil> Get()
        {
            return _context.OyunDilleri.ToArray();
        }

        //get wwww.site.com/OyunDil/5
        [HttpGet("{id}")]
        public ActionResult<OyunDil> GetById(int id)
        {
            var oyundil = _context.OyunDilleri.FirstOrDefault(p => p.Id == id);
            if (oyundil is null)
            {
                return Ok("Böyle bir veri yok");
            }
            return oyundil;
        }

        [HttpPost]
        public ActionResult Post(OyunDilDTO oyundilDTO)
        {
            var oyundil = new OyunDil { OyunID = oyundilDTO.OyunID, DilID = oyundilDTO.DilID };
            _context.OyunDilleri.Add(oyundil);
            _context.SaveChanges();
            return Ok("BAŞARILI");
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, OyunDilDTO oyundilDTO)
        {
            var oyundil = _context.OyunDilleri.FirstOrDefault(p => p.Id == id); //degisecek obje
            /* if (OyunDil is null)
             {
                 OyunDil = new OyunDil { AdSoyad = OyunDilDTO.AdSoyad, Id = id };
                 _context.OyunDilleri.Add(OyunDil);
                 _context.SaveChanges();
                 return CreatedAtAction("Get", new { id = id }, OyunDil);
             }*/
            oyundil.OyunID = oyundilDTO.OyunID;
            oyundil.DilID = oyundilDTO.DilID;

            _context.SaveChanges();
            return Ok("BAŞARILI");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var oyundil = _context.OyunDilleri.FirstOrDefault(p => p.Id == id);
            _context.Remove(oyundil);
            _context.SaveChanges();
            return Ok("BAŞARILI");
        }

        [HttpGet("oyun/{id}")]
        public IEnumerable<OyunDil> GetByOyunId(int id)
        {
            var oyundil = _context.OyunDilleri.Where(p => p.OyunID == id).ToArray();

            return oyundil;
        }
    }
}