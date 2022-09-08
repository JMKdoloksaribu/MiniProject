using MiniProject.Data.Interface.Repositories;
using MiniProject.Model.Entities;
using MiniProject.Service.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Service.Services
{
    public class MusicServices : IMusicServices
    {
        private readonly IMusicRepository musicRepository;

        public MusicServices(IMusicRepository musicRepository)
        {
            this.musicRepository = musicRepository;
        }

        public async Task<bool> Create(string Judul, string Penyanyi, string Genre, int TahunRilis, string[] Publish)
        {
            throw new NotImplementedException();
        }


        public async Task<List<Music>> GetAll()
        {
            var result = await musicRepository.GetAll();
            return result;
        }

  

        public async Task<bool> Delete(int id)
        {
            var result = await musicRepository.Delete(id);
            return result;
        }

        public async Task<List<Publish>> Get(String publish)
        {
            throw new NotImplementedException();
            //var result = await musicRepository.Get(publish);
            //foreach(var p in result)
            //{
            //    p.Publish = await musicRepository.Get(await musicRepository.Get("publish", p.Nama));
            //}
            //return result;
        }


        public Task<bool> Update(Music model, int Id)
        {
            throw new NotImplementedException();
            //var result = await musicRepository.Update(model.Id, model.Judul, model.Penyanyi, model.Genre, model.TahunRilis);
            //await musicRepository.DeletePublish(model.Id);
            //foreach (int mediapublish in model.Publish_id)
            //{
            //    await musicRepository.CreatePublish(model.Id, mediapublish);
            //}
            //return result;
        }

        Task<List<Music>> IMusicServices.Get(string publish)
        {
            throw new NotImplementedException();
        }
    }

}
