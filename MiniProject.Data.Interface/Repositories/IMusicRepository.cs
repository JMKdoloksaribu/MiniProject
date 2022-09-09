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
        public Task<bool> Create(int Id, string Judul, string Penyanyi, string Genre, int TahunRilis);
        public Task<List<Music>> GetAll();
        public Task<bool> Update(int Id, string Judul, string Penyanyi, string Genre, int TahunRilis);
        public Task<bool> Delete(int Id);
        public Task<List<Music>> GetPublish(string Publish2);
        public Task<bool> CheckPublish(string Judul);
        public Task<bool> CheckRelation(int Music_id, int Publish_id);
        public Task<int> GetId(string variableJudul, string Judul);
        public Task<bool> RelateMusicPublish(int MusicId, int PublishId);
        public Task<List<string>> GetPublisher(int Id);
    }
}
