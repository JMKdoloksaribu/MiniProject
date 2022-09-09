using MiniProject.Data.Interface.Repositories;
using MiniProject.Model.Entities;
using MiniProject.Service.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MiniProject.Service.Services
{
    public class MusicServices : IMusicServices
    {
        private readonly IMusicRepository musicRepository;

        public MusicServices(IMusicRepository musicRepository)
        {
            this.musicRepository = musicRepository;
        }

        public async Task<bool> Create(int Id, string Judul, string Penyanyi, string Genre, int TahunRilis, string[] Publish)
        {
            if (await musicRepository.CheckPublish(Judul) == true)
            {
                return false;
            }
            var result = await musicRepository.Create(Id, Judul, Penyanyi, Genre, TahunRilis);
            int MusicId = await musicRepository.GetId("music", Judul);
            foreach (string p in Publish)
            {
                int PublishId = await musicRepository.GetId("publish", p);
                await musicRepository.RelateMusicPublish(MusicId, PublishId);
            }
            return result;
        }


        public async Task<List<Music>> GetAll()
        {
            var result = await musicRepository.GetAll();
            foreach (var p in result)
            {
                p.Publish = await musicRepository.GetPublisher(await musicRepository.GetId("music", p.Judul));
            }
            return result;
        }

        public async Task<bool> Delete(int Id)
        {
            var result = await musicRepository.Delete(Id);
            return result;
        }

        public async Task<List<Music>> GetPublish(String Publish2)
        {
            var result = await musicRepository.GetPublish(Publish2);
            foreach (var p in result)
            {
                p.Publish = await musicRepository.GetPublisher(await musicRepository.GetId("music", p.Judul));
            }
            return result;
        }


        public async Task<bool> Update(Music model, int Id)
        {
            var result = await musicRepository.Update(model.Id, model.Judul, model.Penyanyi, model.Genre, model.TahunRilis);
            foreach (string p in model.Publish)
            {
                int PublishId = await musicRepository.GetId("publish", p);
                if (await musicRepository.CheckRelation(Id, PublishId))
                {
                    continue;
                }
                else
                {
                    await musicRepository.RelateMusicPublish(Id, PublishId);
                }
            }
            return true;
        }
    }

}
