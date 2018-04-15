using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr_secret.Models;

namespace keepr_secret.Repositories
{
    public class KeepRepository
    {
        private readonly IDbConnection _db;
        public KeepRepository(IDbConnection db)
        {
            _db = db;
        }

        //Create Keep
        public Keep CreateKeep(Keep keep)
        {
            int id = _db.ExecuteScalar<int>($@"
            INSERT INTO keeps (
                Name, 
                ImageUrl,
                Description, 
                UserId, 
                Views, 
                Saves)"
                + $@" VALUES(
                    @Name, 
                    @ImageUrl, 
                    @Description, 
                    @UserId, 
                    @Views, 
                    @Saves); 
                    SELECT LAST_INSERT_ID()", new
                {
                    keep.Name,
                    keep.ImageUrl,
                    keep.Description,
                    keep.UserId,
                    keep.Views,
                    keep.Saves
                });
            keep.Id = id;
            return keep;
        }

        //GET ONE BY ID AND UPDATE
        public Keep UpdateKeep(int id, Keep keep)
        {
            return _db.QueryFirstOrDefault<Keep>($@"
            UPDATE keeps SET                   
            Name = @Name,
            Description = @Description,
            Views = @Views,
            Saves = @Saves,
            UserId = @UserId
            WHERE Id = {id};
            SELECT * FROM keeps WHERE id = {id};", keep
            );
        }

        //DELETE KEEP
        public string DeleteKeep(int id)
        {
            var success = _db.Execute($@"
            DELETE FROM keeps WHERE Id = {id}", id
            );
            return success > 0 ? "success" : "umm that didnt work";
        }

        //GET ALL KEEPS
        public IEnumerable<Keep> GetAllKeeps()
        {
            return _db.Query<Keep>("SELECT * FROM keeps");
        }

        //GET BY USER ID
        public IEnumerable<Keep> GetKeepsByUser(int userId)
        {
            return _db.Query<Keep>($@"
            SELECT * FROM keeps WHERE UserId = {userId}
            ");
        }
    }
}