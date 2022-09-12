using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniProject.Model.Entities;

namespace MiniProject.Service.Interface.Services
{
    public interface IDbServices
    {
        Task<int> InsertData(string command, object param);
        Task<List<T>> GetData<T>(string command, object param);
        Task<int> DeleteMusic(string command, object param);
        Task<int> DeletePublish(string command, object param);
    }
}
