using Microsoft.AspNetCore.Mvc;
using MiniProject.Model.Entities;
using MiniProject.Service.Interface.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace MiniProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicController : Controller
    {
        private readonly IMusicServices musicServices;

        public MusicController(IMusicServices musicServices)
        {
            this.musicServices = musicServices;
        }

        [HttpPost]
        //public async Task<IActionResult> Create([FromBody] Music model)
        //{
        //    var result = await musicServices.Create(model);
        //    return Ok(result);
        //}

        [HttpGet]
        public async Task<List<Music>> GetAll()
        { 
            var result = await musicServices.GetAll();
            return result;
        }

        [HttpPut]
        //public async Task<IActionResult> Update([FromBody] Music_has_Publish model)
        //{
        //    var result = await musicServices.Update(model);
        //    return Ok(result);
        //}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await musicServices.Delete(id);
            return Ok(result);
        }

        [HttpGet("{publish}")]
        public async Task<ActionResult<Music>> Get(string publish)
        {
            var result = await musicServices.Get(publish);
            return Ok(result);
        }

    }
}
