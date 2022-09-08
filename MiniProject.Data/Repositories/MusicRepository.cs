using MiniProject.Data.Interface.Repositories;
using MiniProject.Model.Entities;
using MiniProject.Service.Interface.Services;
using MiniProject.Service.Services;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Data.Repositories
{
    public class MusicRepository : IMusicRepository
    {
        private readonly IDbServices _dbServices;

        public MusicRepository(IDbServices dbServices)
        {
            _dbServices = dbServices;
        }
        public async Task<bool> Create(Music model)
        {
            await _dbServices.ModifyData("Insert into Music " +
                "(id, judul, genre, penyanyi, tahunRilis)" +
                "values" +
                "(@Id, @Judul, @Genre, @Penyanyi, @TahunRilis);", model);
            await _dbServices.ModifyData("Insert into publish " +
                "(publish)" +
                "values (@publish);", model);
            await _dbServices.ModifyData("Insert into music_has_publish (music_id, publish_id)" +
                "values ((select m.id from music m order by m.id desc), LAST_INSERT_ID())", model);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _dbServices.ModifyData("delete from music_has_publish mp where mp.music_id=@Id;", new { id });
            await _dbServices.ModifyData("delete from music m where m.id=@Id;", new { id });
            return true;
        }


        public async Task<List<Music>> GetAll()
        {
            var result = await _dbServices.GetData<Music>
                ("select m.id, m.judul, m.penyanyi, m.tahunRilis, m.genre," +
                " group_concat(p.nama) publish from music m" +
                " join music_has_publish mp" +
                " on m.id = mp.music_id" +
                " join publish p" +
                " on mp.publish_id = p.id" +
                " group by m.id limit 10;", new { });
            return result;
        }

        public async Task<bool> UpdatePublish(int Id, int Publish_id)
        {
            await _dbServices.ModifyData("update Music_has_Publish" +
                " set judul=@Judul, genre=@Genre, penyanyi=@Penyanyi, tahunRilis=@TahunRilis " +
                "where id=@Id", new {Id=@Id, Publish_id=Publish_id});
            return true;
        }

        //public async Task<bool> Update(int Id, string Judul, string Penyanyi, string Genre, string TahunRilis)
        //{
        //    await _dbServices.ModifyData("update music" +
        //        " set judul=@Judul, genre=@Genre, penyanyi=@Penyanyi, tahunRilis=@TahunRilis " +
        //        "where id=@Id", new { Id, Judul, Penyanyi, Genre, TahunRilis});
        //    return true;
        //}

        public async Task<List<Music>> Get(String publish)
        {
            throw new NotImplementedException();
            //var result = await _dbServices.Get<Music>("select * from publish p where p.id=@Id", new { publish });
            //return result;
        }

        public Task<bool> CreatePublish(int Id, int Publish_id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int Id, string Judul, string Penyanyi, string Genre, int TahunRilis)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePublish(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(string Judul, string Penyanyi, string Genre, int TahunRilis)
        {
            throw new NotImplementedException();
        }
    }
}
