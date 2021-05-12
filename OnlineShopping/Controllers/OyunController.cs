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
    [Route("oyun")]
    [ApiController]
    public class OyunController : Controller
    {
        private readonly ModelContext _context;

        public OyunController(ModelContext context)
        {
            _context = context;
        }

        //get wwww.site.com/oyun
        [HttpGet]
        public IEnumerable<Oyun> Get()
        {
            return _context.Oyunlar.ToArray();
        }

        //get wwww.site.com/oyun/5
        [HttpGet("{id}")]
        public ActionResult<Oyun> GetById(int id)
        {
            var oyun = _context.Oyunlar.FirstOrDefault(p => p.Id == id);
            if (oyun is null)
            {
                return Ok("Böyle bir veri yok");
            }
            return oyun;
        }

        [HttpPost]
        public ActionResult Post(OyunDTO oyunDTO)
        {
            var oyun = new Oyun { Ad = oyunDTO.Ad, CikisTarihi = oyunDTO.CikisTarihi, Fiyat = oyunDTO.Fiyat, FirmaID = oyunDTO.FirmaID, PlatformID = oyunDTO.PlatformID };
            _context.Oyunlar.Add(oyun);
            _context.SaveChanges();
            return Ok("BAŞARILI");
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, OyunDTO oyunDTO)
        {
            var oyun = _context.Oyunlar.FirstOrDefault(p => p.Id == id); //degisecek obje
            /* if (oyun is null)
             {
                 oyun = new Oyun { AdSoyad = oyunDTO.AdSoyad, Id = id };
                 _context.Oyunlar.Add(oyun);
                 _context.SaveChanges();
                 return CreatedAtAction("Get", new { id = id }, oyun);
             }*/
            oyun.Ad = oyunDTO.Ad;
            oyun.CikisTarihi = oyunDTO.CikisTarihi;
            oyun.Fiyat = oyunDTO.Fiyat;
            oyun.FirmaID = oyunDTO.FirmaID;
            oyun.PlatformID = oyunDTO.PlatformID;

            _context.SaveChanges();
            return Ok("BAŞARILI");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var oyun = _context.Oyunlar.FirstOrDefault(p => p.Id == id);
            _context.Remove(oyun);
            _context.SaveChanges();
            return Ok("BAŞARILI");
        }
    }
}