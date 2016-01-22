using MusicAPI.Models;
using MusicAPI.Repository;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System;

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    public class MusicController : Controller
    {
        [FromServices]
        public IMusicRepository MusicRepo { get; set; }

        [HttpGet]
        public IEnumerable<Music>GetAll()
        {            
            return MusicRepo.GetAll();
        }

        [HttpGet("{id}", Name = "GetMusic")]
        public IActionResult GetById(Guid id)
        {
            var item = MusicRepo.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Music item)
        {
            if (item == null)
            {
                return HttpBadRequest();
            }
            MusicRepo.Add(item);
            return CreatedAtRoute("GetMusic", new { Controller = "Music", id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Music item)
        {
            if (item == null)
            {
                return HttpBadRequest();
            }
            var contactObj = MusicRepo.Find(id);
            if (contactObj == null)
            {
                return HttpNotFound();
            }
            MusicRepo.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            MusicRepo.Remove(id);
        }
    }
}