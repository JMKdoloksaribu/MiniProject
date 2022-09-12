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
            var result = await musicServices.Create(model);
            return Ok(result);
        }

        [HttpGet]
        public async Task<List<MusicPublish>> Get(int page)
        {
            List<MusicPublish> result = await musicServices.Get(page);
            return result;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Music model)
        {
            var result = await musicServices.Update(model);
            return Ok(result);
        }

        [HttpDelete("{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await musicServices.Delete(Id);
            return Ok(result);
        }

        [HttpGet("{mediapublish}")]
        public async Task<List<MusicPublish>> GetMediaPublish(string mediapublish)
        {
            List<MusicPublish> result = await musicServices.GetMediaPublish(mediapublish);
            return result;
        }
    }
}
