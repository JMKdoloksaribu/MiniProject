using MiniProject.Data.Interface.Repositories;
using MiniProject.Model.Entities;
using MiniProject.Service.Interface.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniProject.Service.Services;
using MySqlX.XDevAPI.Common;
using System;
using System.Linq;
using System.Text;

namespace MiniProject.Data.Repositories
{
    public class MusicRepository : IMusicRepository
    {
        private readonly IDbServices _dbServices;

        public MusicRepository(IDbServices dbServices)
        {
            _dbServices = dbServices;
        }
        public async Task<bool> CreateMusic(Music model)
        {
            await _dbServices.InsertData("Insert into Music " +
                "( Id, Nama, Genre, Penyanyi, TahunRilis ) " +
                " values " +
                "( @Id, @Nama, @Genre, @Penyanyi, @TahunRilis);", model);
            return true;
        }

        public async Task<bool> CreatePublish(string mediapublish, int Id)
        {
            await _dbServices.InsertData("Insert into Publish ( Id, Nama ) " +
                " values " +
                " (( select p.Id from Publish p order by p.Id DESC limit 1)+1,@mediapublish ) ;" +
                " Insert into Music_has_Publish mp (Music_id, Publish_id ) " +
                " values " +
                " (@Id,(select p.Id from Publish p order by p.Id DESC limit 1));", new { mediapublish, Id }); ;
            return true;
        }

        public async Task<bool> CreateMusicPublish(string mediapublish, int Id)
        {
            await _dbServices.InsertData("Insert into Music_has_Publish ( Music_id, Publish_id ) " +
                " values " +
                " (@Id,(select p.Id from Publish p where p.Nama = @mediapublish));", new { mediapublish, Id });
            return true;
        }


        public async Task<bool> Delete(int Id)
        {
            await _dbServices.DeletePublish("delete from Music_has_Publish mp where mp.Music_id=@Id;", new { Id });
            await _dbServices.DeleteMusic("delete from Music m where m.Id=@Id;", new { Id });
            return true;
        }

        public async Task<bool> DeleteMP(int Id)
        {
            await _dbServices.DeletePublish("delete from Music_has_Publish mp " +
                " where mp.Music_id = @Id;", new { Id });
            return true;
        }

        public async Task<List<MusicPublish>> GetAll(int page)
        {
            var result = await _dbServices.GetData<MusicPublish>(
                " select m.Id, m.Nama, m.Penyanyi, m.TahunRilis, m.Genre, group_concat(p.Nama) Publish " +
                " from Music m " +
                " join Music_has_Publish mp " +
                " on m.Id = mp.Music_id " +
                " join Publish p " +
                " on mp.Publish_id = p.Id " +
                " where m.Id > (10*(@page-1)) and m.Id <= (10*@page) group by m.Id;", new { page });
            return result;
        }

        public async Task<List<int>> GetMusic(int Id)
        {
            var result = await _dbServices.GetData<int>(
                " select m.Id from Music m where m.Id = @Id;", new { Id });
            return result;
        }
        public async Task<List<MusicPublish>> GetPublish(string mediapublish)
        {
            var result = await _dbServices.GetData<MusicPublish>(
                " select m.Id, m.Nama, m.Penyanyi, m.TahunRilis, group_concat(p.Nama) Publish " +
                " from Music m " +
                " join Music_has_Publish mp " +
                " on m.Id = mp.Music_id " +
                " join Publish p " +
                " on mp.Publish_id = p.Id " +
                " where p.Nama = @mediapublish group by m.Id;", new { mediapublish });
            return result;
        }
        public async Task<List<string>> PublishGet()
        {
            List<string> result = await _dbServices.GetData<string>(
                " select p.Nama from Publish p;", new { });
            return result;
        }

        public async Task<Music> UpdateMusic(Music model)
        {
            await _dbServices.InsertData("update Music " +
                " set Nama=@Nama, Penyanyi=@Penyanyi, TahunRilis=@TahunRilis, Genre=@Genre " +
                " where Id=@Id;", model);
            return model;
        }
        public async Task<bool> UpdatePublish(string mediapublish, int Id)
        {
            await _dbServices.InsertData(
                " insert into Music_has_Publish (Music_id, Publish_id ) " +
                " values (@Id,(select p.id from Publish p where p.Nama = @mediapublish));",
                new { mediapublish, Id });
            return true;
        }
    }
}