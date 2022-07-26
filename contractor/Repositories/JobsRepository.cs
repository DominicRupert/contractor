using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using contractor.Models;
using Dapper;

namespace contractor.Repositories
{
    public class JobsRepository
    {
        private readonly IDbConnection _db;

        public JobsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Job Create(Job newJob)
        {
            string sql = @"
            INSERT INTO jobs
            (name, contractorId, companyId)
            VALUES
            (@Name, @ContractorId, @CompanyId);
            SELECT LAST_INSERT_ID();";
            newJob.Id = _db.ExecuteScalar<int>(sql, newJob);
            return newJob;
        }

        internal Job CheckForExistingJob(Job newJob)
        {
            string sql = @"
            SELECT * FROM jobs
            WHERE contractorId = @ContractorId AND companyId = @CompanyId Limit 1;
            ";
            return _db.QueryFirstOrDefault<Job>(sql, newJob);
        }

        internal List<Job> Get()
        {
            string sql = "SELECT * FROM jobs;";
            return _db.Query<Job>(sql).ToList();
        }

        internal Job Get(int id)
        {
            string sql = "SELECT * FROM jobs WHERE id = @Id";
            return _db.QueryFirstOrDefault<Job>(sql, new { id });
        }

        internal List<CompanyJobViewModel> GetByCompanyId(int id)
        {
            string sql = @"
            SELECT
            c.*,
            j.id AS jobId,
            From jobs j
            JOIN companies c ON c.id = j.companyId
            WHERE j.contractorId = @Id;
            ";
            return _db.Query<CompanyJobViewModel>(sql, new { id }).ToList();
        }

        internal List<ContractorJobViewModel> GetByContractorId(int id)
        {
            string sql = @"
            SELECT
            cons.*,
            j.id AS jobId,
            From jobs j
            JOIN contractors cons ON cons.id = j.contractorId
            WHERE j.companyId = @Id;
            ";
            return _db.Query<ContractorJobViewModel>(sql, new { id }).ToList();
        }

        internal void Delete(int id)
        {
            string sql = @"
            DELETE FROM jobs
            WHERE id = @Id;
            LIMIT 1";
            _db.Execute(sql, new { id });
        }
    }
}