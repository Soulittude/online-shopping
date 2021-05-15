using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Models;
using OnlineShopping.Models.DTO;
using OnlineShopping.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Controllers
{
    [Route("tag")]
    [ApiController]
    public class TagController : Controller
    {
        private readonly ModelContext _context;

        public TagController(ModelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Tag> Get()
        {
            return _context.Tagler.ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<Tag> GetById(int id)
        {
            var tag = _context.Tagler.FirstOrDefault(p => p.Id == id);
            if (tag is null)
            {
                return Ok("Veri bulunamadı");
            }
            return tag;
        }

        [HttpPost]
        public ActionResult Post(TagDTO tagDTO)
        {
            var tag = new Tag { Ad = tagDTO.Ad };
            _context.Tagler.Add(tag);
            _context.SaveChanges();
            return Ok("Veri ekleme işlemi başarılı");
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, TagDTO tagDTO)
        {
            var tag = _context.Tagler.FirstOrDefault(p => p.Id == id);

            tag.Ad = tagDTO.Ad;
            _context.SaveChanges();
            return Ok("Veri güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var tag = _context.Tagler.FirstOrDefault(p => p.Id == id);
            _context.Remove(tag);
            _context.SaveChanges();
            return Ok("Veri silme işlemi başarılı");
        }
    }
}
