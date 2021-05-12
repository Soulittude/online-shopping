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
    [Route("platform")]
    [ApiController]
    public class PlatformController : Controller
    {
        private readonly ModelContext _context;

        public PlatformController(ModelContext context)
        {
            _context = context;
        }

        //get wwww.site.com/platform
        [HttpGet]
        public IEnumerable<Platform> Get()
        {
            return _context.Platformlar.ToArray();
        }

        //get wwww.site.com/platform/5
        [HttpGet("{id}")]
        public ActionResult<Platform> GetById(int id)
        {
            var platform = _context.Platformlar.FirstOrDefault(p => p.Id == id);
            if(platform is null)
            {
                return Ok("Böyle bir veri yok");
            }
            return platform;
        }

        [HttpPost]
        public ActionResult Post(PlatformDTO platformDTO)
        {
            var platform = new Platform { Ad = platformDTO.Ad };
            _context.Platformlar.Add(platform);
            _context.SaveChanges();
            return Ok("BAŞARILI");
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, PlatformDTO platformDTO)
        {
            var platform = _context.Platformlar.FirstOrDefault(p => p.Id == id); //degisecek obje
           /* if (platform is null)
            {
                platform = new Platform { AdSoyad = platformDTO.AdSoyad, Id = id };
                _context.Platformlar.Add(platform);
                _context.SaveChanges();
                return CreatedAtAction("Get", new { id = id }, platform);
            }*/
            platform.Ad = platformDTO.Ad;
            _context.SaveChanges();
            return Ok("BAŞARILI");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var platform = _context.Platformlar.FirstOrDefault(p => p.Id == id);
            _context.Remove(platform);
            _context.SaveChanges();
            return Ok("BAŞARILI");
        }
    }
}