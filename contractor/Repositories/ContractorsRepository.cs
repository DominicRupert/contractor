using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using contractor.Models;

namespace contractor.Repositories
{
    public class ContractorsRepository
    {
        private readonly IDbConnection _db;

        public ContractorsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal List<Contractor> Get()
        {
            string sql = "SELECT * FROM contractors";
            return _db.Query<Contractor>(sql).ToList();
        }

        internal Contractor Get(int id)
        {
            string sql = "SELECT * FROM contractors WHERE id = @id";
            return _db.QueryFirstOrDefault<Contractor>(sql, new { id });
        }

        internal Contractor Create(Contractor contractor)
        {
            string sql = @"
            INSERT INTO contractors
            (name, profession)
            VALUES
            (@Name, @Profession);
            SELECT LAST_INSERT_ID();";
            contractor.Id = _db.ExecuteScalar<int>(sql, contractor);
            return contractor;
        }

        internal void Edit(int id, Contractor original)
        {
            string sql = @"
            UPDATE contractors
            SET name = @Name, profession = @Profession
            WHERE id = @id";
            _db.Execute(sql, original);
        }

        internal void Edit(Contractor original)
        {
            string sql = @"
            UPDATE contractors
            SET name = @Name, profession = @Profession
            WHERE id = @id";
            _db.Execute(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = @"
            DELETE FROM contractors
            WHERE id = @id;
            LIMIT 1";
            _db.Execute(sql, new { id });
        }
        
    }
}