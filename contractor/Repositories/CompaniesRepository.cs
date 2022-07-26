using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using contractor.Models;

namespace contractor.Repositories
{
    public class CompaniesRepository
    {
        private readonly IDbConnection _db;

        public CompaniesRepository(IDbConnection db)
        {
            _db = db;
        }
        internal List<Company> Get()
        {
            string sql = "SELECT * FROM companies";
            return _db.Query<Company>(sql).ToList();
        }

        internal Company Get(int id)
        {
            string sql = "SELECT * FROM companies WHERE id = @id";
            return _db.QueryFirstOrDefault<Company>(sql, new { id });
        }

        internal Company Create(Company company)
        {
            string sql = @"
            INSERT INTO companies
            (name)
            VALUES
            (@Name);
            SELECT LAST_INSERT_ID();";
            company.Id = _db.ExecuteScalar<int>(sql, company);
            return company;
        }

        internal Company Edit(int id, Company original)
        {
            string sql = @"
            UPDATE companies
            SET name = @Name
            WHERE id = @Id;
           ";
            return _db.QueryFirstOrDefault<Company>(sql, original);
        }

        internal void Edit(Company original)
        {
            throw new NotImplementedException();
        }

        internal void Delete(int id)
        {
            string sql = @"
            DELETE FROM companies
            WHERE id = @Id;
            LIMIT 1";
            _db.Execute(sql, new { id });
        }



        
    }
}