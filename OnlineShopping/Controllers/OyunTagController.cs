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

        [HttpGet]
        public IEnumerable<OyunTag> Get()
        {
            return _context.OyunTagleri.ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<OyunTag> GetById(int id)
        {
            var oyuntag = _context.OyunTagleri.FirstOrDefault(p => p.Id == id);
            if (oyuntag is null)
            {
                return Ok("Veri bulunamadı");
            }
            return oyuntag;
        }

        [HttpPost]
        public ActionResult Post(OyunTagDTO oyuntagDTO)
        {
            var oyuntag = new OyunTag { OyunID = oyuntagDTO.OyunID, TagID = oyuntagDTO.TagID };
            _context.OyunTagleri.Add(oyuntag);
            _context.SaveChanges();
            return Ok("Veri ekleme işlemi başarılı");
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, OyunTagDTO oyuntagDTO)
        {
            var oyuntag = _context.OyunTagleri.FirstOrDefault(p => p.Id == id);
            oyuntag.OyunID = oyuntagDTO.OyunID;
            oyuntag.TagID = oyuntagDTO.TagID;

            _context.SaveChanges();
            return Ok("Veri güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var oyuntag = _context.OyunTagleri.FirstOrDefault(p => p.Id == id);
            _context.Remove(oyuntag);
            _context.SaveChanges();
            return Ok("Veri silme işlemi başarılı");
        }

        [HttpGet("oyun/{id}")]
        public IEnumerable<OyunTag> GetByOyunId(int id)
        {
            var oyuntag = _context.OyunTagleri.Where(p => p.OyunID == id).ToArray();
            return oyuntag;
        }
    }
}