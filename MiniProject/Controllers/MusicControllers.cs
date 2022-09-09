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
        public async Task<IActionResult> Create([FromBody] Music model)
        {
            var result = await musicServices.Create(model.Id, model.Judul, model.Penyanyi, model.Genre, model.TahunRilis, model.Publish.ToArray());
            return Ok(result);
        }

        [HttpGet]
        public async Task<List<Music>> GetAll()
        { 
            var result = await musicServices.GetAll();
            return result;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Music model, int Id)
        {
            var result = await musicServices.Update(model, Id);
            return Ok(result);
        }

        [HttpDelete("{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await musicServices.Delete(Id);
            return Ok(result);
        }

        [HttpGet("{publish}")]
        public async Task<List<Music>> GetPublish(string publish)
        {
            var result = await musicServices.GetPublish(publish);
            return result;
        }

    }
}
