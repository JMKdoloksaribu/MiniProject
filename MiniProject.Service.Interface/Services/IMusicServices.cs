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
        public Task<bool> Create(Music model);
        public Task<List<MusicPublish>> Get(int page);

        public Task<bool> Update(Music model);
        public Task<bool> Delete(int Id);
        public Task<List<MusicPublish>> GetMediaPublish(string publishmedia); 
    }
}
