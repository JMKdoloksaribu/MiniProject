using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Service.Interface.Services
{
    public interface IDbServices
    {
        Task<int> ModifyData(string command, object param);
        Task<List<T>> GetData<T>(string command, object param);
        Task<T> Get<T>(string command, object param);
        Task<bool> Check(string command, object param);
    }
}
