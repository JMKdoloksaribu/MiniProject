using Dapper;
using Microsoft.Extensions.Configuration;
using MiniProject.Service.Interface.Services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Service.Services
{
    public class DbServices : IDbServices
    {
        private readonly IDbConnection _db;

        public DbServices(IConfiguration configuration)
        {
            _db = new MySqlConnection(configuration.GetConnectionString("Connectminiproject"));
        }

        public async Task<List<T>> GetData<T>(string command, object param)
        {
            List<T> result = (await _db.QueryAsync<T>(command, param)).ToList();
            return result;
        }

        public async Task<int> ModifyData(string command, object param)
        {
            var result = await _db.ExecuteAsync(command, param);
            return result;
        }

        public async Task<T> Get<T>(string command, object param)
        {
            T result = await _db.QuerySingleAsync<T>(command, param);
            return result;
        }
        public async Task<bool> Check(string command, object param)
        {
            var result = await _db.ExecuteScalarAsync<bool>(command, param);
            return result;
        }
    }
}
