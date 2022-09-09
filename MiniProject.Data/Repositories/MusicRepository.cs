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
using System.Xml.Linq;

namespace MiniProject.Data.Repositories
{
    public class MusicRepository : IMusicRepository
    {
        private readonly IDbServices _dbServices;

        public MusicRepository(IDbServices dbServices)
        {
            _dbServices = dbServices;
        }
        public async Task<bool> Create(int Id, string Judul, string Penyanyi, string Genre, int TahunRilis)
        {
            await _dbServices.ModifyData("Insert into Music" +
                "( Id, Judul, Genre, Penyanyi, TahunRilis)" +
                " values" +
                "( @Id, @Judul, @Genre, @Penyanyi, @TahunRilis);", new { Id=Id, Judul = Judul, Penyanyi = Penyanyi, Genre = Genre, TahunRilis=TahunRilis });
            return true;
        }

        public async Task<bool> Delete(int Id)
        {
            await _dbServices.ModifyData("delete from Music_has_Publish mp where mp.Music_id=@Id;", new { Id });
            await _dbServices.ModifyData("delete from Music m where m.Id=@Id;", new { Id });
            return true;
        }


        public async Task<List<Music>> GetAll()
        {
            var result = await _dbServices.GetData<Music>
                ("select m.Id, m.Judul, m.Penyanyi, m.TahunRilis, m.Genre" +
                " from Music m" +
                " join Music_has_Publish mp" +
                " on m.Id = mp.Music_id" +
                " join Publish p" +
                " on mp.Publish_id = p.Id" +
                " group by m.Id limit 10;", new {});
            return result;
        }

        public async Task<List<string>> GetPublisher(int Id)
        {
            var result = await _dbServices.GetData<string>("select p.Nama from Music m " +
                " join Music_has_Publish mp on m.Id=mp.Publish_id" +
                " join Publish p on mp.Music_id=p.Id" +
                " where m.Id=@Id", new { Id=Id });
            return result;
        }

        public async Task<bool> Update(int Id, string Judul, string Penyanyi, string Genre, int TahunRilis)
        {
            await _dbServices.ModifyData("update Music" +
                " set Judul=@Judul, Penyanyi=@Penyanyi, Genre=@Genre, TahunRilis=@TahunRilis" +
                " where Id=@Id;", new { Id, Judul, Genre, Penyanyi, TahunRilis });
            return true;
        }

        public async Task<List<Music>> GetPublish(string Publish2)
        {
            var result = await _dbServices.GetData<Music>
                ("select m.Id, m.Judul, m.Penyanyi, m.Genre, m.TahunRilis" +
                " from Music m " +
                " join Music_has_Publish mp on m.Id=mp.Publish_id" +
                " join Publish p on mp.Music_id=p.Id" +
                " where p.Nama like @Publish2" +
                " group by m.Id;", new {Publish2=Publish2 });
            return result;
        }

        public async Task<bool> CheckPublish(string Judul)
        {
            var result = await _dbServices.Check("select count(1) from Music" +
                " where Judul=@Judul", new { Judul=Judul });
            return result;
        }

        public async Task<bool> CheckRelation(int Music_id, int Publish_id)
        {
            var result = await _dbServices.Check("select count(1) from Music_has_Publish" +
                " where Music_id=@Music_id and Publish_id=@Publish_id", new { Music_id = Music_id, Publish_id=Publish_id});
            return result;
        }

        public async Task<bool> RelateMusicPublish(int MusicId, int PublishId)
        {
            await _dbServices.ModifyData("insert into Music_has_Publish" +
                " values (@Music_id,@Publish_id);", new { Music_id=MusicId, Publish_id=PublishId });
            return true;
        }

        public async Task<int> GetId(string variableJudul, string Judul)
        {
            int Id = await _dbServices.Get<int>("select Id from " + variableJudul +  " where Judul=@Judul", new { Judul=Judul });
            return Id;
        }
    }
}
