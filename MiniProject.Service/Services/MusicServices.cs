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

        public async Task<bool> Create(Music model)
        {
            Publish publish = new Publish();
            publish.Nama = model.Publish;
            int Id = model.Id;
            await musicRepository.CreateMusic(model);
            List<string> data = await musicRepository.PublishGet();
            Publish publishData = new Publish();
            publishData.Nama = data;

            foreach (string mediapublish in publish.Nama)
            {
                if (!publishData.Nama.Contains(mediapublish))
                {
                    await musicRepository.CreatePublish(mediapublish, Id);
                }
                else if (publishData.Nama.Contains(mediapublish))
                {
                    await musicRepository.CreateMusicPublish(mediapublish, Id);
                }
            }
            return true;
        }

        public async Task<List<MusicPublish>> Get(int page)
        {
            List<MusicPublish> result = await musicRepository.GetAll(page);
            return result;
        }
        public async Task<bool> Delete(int Id)
        {
            var result = await musicRepository.Delete(Id);
            return result;
        }

        public async Task<List<MusicPublish>> GetMediaPublish(String mediapublish)
        {
            List<MusicPublish> result = await musicRepository.GetPublish(mediapublish);
            return result;
        }


        public async Task<bool> Update(Music model)
        {
            await musicRepository.UpdateMusic(model);
            Publish publish = new Publish();
            publish.Nama = model.Publish;
            List<string> data = await musicRepository.PublishGet();
            Publish publishData = new Publish();
            publishData.Nama = data;
            await musicRepository.DeleteMP(model.Id);
            foreach (string mediapublish in publish.Nama)
            {
                if (!publishData.Nama.Contains(mediapublish))
                {
                    await musicRepository.CreatePublish(mediapublish, model.Id);
                }
                else if (publishData.Nama.Contains(mediapublish))
                {
                    await musicRepository.UpdatePublish(mediapublish, model.Id);
                }
            }
            return true;
        }
    }

}
