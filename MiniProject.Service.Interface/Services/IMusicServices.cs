using MiniProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Service.Interface.Services
{
    public interface IMusicServices
    {
        public Task<bool> Create(string Judul, string Penyanyi, string Genre, int TahunRilis, string[] Publish);
        //public Task<bool> Create(Music model);
        public Task<List<Music>> GetAll();
        public Task<bool> Update(Music model, int Id);
        public Task<bool> Delete(int id);
        public Task<List<Music>> Get(string publish); 
    }
}
