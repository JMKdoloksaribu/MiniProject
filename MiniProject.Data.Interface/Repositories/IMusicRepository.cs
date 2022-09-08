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
        public Task<bool> Create(string Judul, string Penyanyi, string Genre, int TahunRilis);
        public Task<bool> CreatePublish(int Id, int Publish_id);
        public Task<List<Music>> GetAll();
        public Task<bool> Update(int Id, string Judul, string Penyanyi, string Genre, int TahunRilis);
        public Task<bool> UpdatePublish(int Id, int Publish_id);
        public Task<bool> Delete(int Id);
        public Task<bool> DeletePublish(int Id);
        public Task<List<Music>> Get(string publish);
    }
}
