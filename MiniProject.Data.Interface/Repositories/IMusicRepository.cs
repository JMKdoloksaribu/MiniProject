using MiniProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Data.Interface.Repositories
{
    public interface IMusicRepository
    {
        public Task<bool> CreateMusic(Music model);
        public Task<bool> CreatePublish(string mediapublish, int Id);
        public Task<bool> CreateMusicPublish(string mediapublish, int Id );
        public Task<List<MusicPublish>> GetAll(int page);
        public Task<List<int>> GetMusic(int Id);
        public Task<List<MusicPublish>> GetPublish(string mediapublish);
        public Task<List<string>> PublishGet();
        public Task<Music> UpdateMusic(Music model);
        public Task<bool> UpdatePublish(string mediapublish, int Id);
        public Task<bool> Delete(int Id);
        public Task<bool> DeleteMP(int Id);
    }
}
