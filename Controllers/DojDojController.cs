using DojDojApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DojDojApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DojDojController : ControllerBase
    {
        private static List<DojDoj> _dojDoj = new List<DojDoj>()
        {
            new DojDoj() { Id = 1, Name = "DojDoj", Horde = "The Dojers", ThrallName = "BBEG" },
            new DojDoj() { Id = 2, Name = "Gösta", Horde = "Gösta's Grabbers", ThrallName = "Ärke-Gösta" }
        };

        [HttpPost]
        public IActionResult Post(DojDoj dojDoj)
        {
            _dojDoj.Add(dojDoj);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dojDoj);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_dojDoj.FirstOrDefault(x => x.Id == id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(DojDoj dojDoj)
        {
            var dojDojToUpdate = _dojDoj.FirstOrDefault(x => x.Id == dojDoj.Id);
            if (dojDoj == null)
            {
                return NotFound();
            }

            dojDojToUpdate.Name = dojDoj.Name;
            dojDojToUpdate.Horde = dojDoj.Horde;
            dojDojToUpdate.ThrallName = dojDoj.ThrallName;

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dojDojToDelete = _dojDoj.FirstOrDefault(x => x.Id == id);
            if (dojDojToDelete == null)
            {
                return NotFound();
            }

            _dojDoj.Remove(dojDojToDelete);
            return Ok();
        }
    }
}
