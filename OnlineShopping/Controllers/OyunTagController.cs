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
    [Route("oyuntag")]
    [ApiController]
    public class OyunTagController : Controller
    {
        private readonly ModelContext _context;

        public OyunTagController(ModelContext context)
        {
            _context = context;
        }

        //get wwww.site.com/OyunTag
        [HttpGet]
        public IEnumerable<OyunTag> Get()
        {
            return _context.OyunTagleri.ToArray();
        }

        //get wwww.site.com/OyunTag/5
        [HttpGet("{id}")]
        public ActionResult<OyunTag> GetById(int id)
        {
            var oyuntag = _context.OyunTagleri.FirstOrDefault(p => p.Id == id);
            if (oyuntag is null)
            {
                return Ok("Böyle bir veri yok");
            }
            return oyuntag;
        }

        [HttpPost]
        public ActionResult Post(OyunTagDTO oyuntagDTO)
        {
            var oyuntag = new OyunTag { OyunID = oyuntagDTO.OyunID, TagID = oyuntagDTO.TagID };
            _context.OyunTagleri.Add(oyuntag);
            _context.SaveChanges();
            return Ok("BAŞARILI");
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, OyunTagDTO oyuntagDTO)
        {
            var oyuntag = _context.OyunTagleri.FirstOrDefault(p => p.Id == id); //degisecek obje
            /* if (OyunTag is null)
             {
                 OyunTag = new OyunTag { AdSoyad = OyunTagDTO.AdSoyad, Id = id };
                 _context.OyunTagleri.Add(OyunTag);
                 _context.SaveChanges();
                 return CreatedAtAction("Get", new { id = id }, OyunTag);
             }*/
            oyuntag.OyunID = oyuntagDTO.OyunID;
            oyuntag.TagID = oyuntagDTO.TagID;

            _context.SaveChanges();
            return Ok("BAŞARILI");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var oyuntag = _context.OyunTagleri.FirstOrDefault(p => p.Id == id);
            _context.Remove(oyuntag);
            _context.SaveChanges();
            return Ok("BAŞARILI");
        }
    }
}