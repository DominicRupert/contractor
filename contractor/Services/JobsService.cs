using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contractor.Models;
using contractor.Repositories;

namespace contractor.Services
{
    public class JobsService
    {

        private readonly JobsRepository _repo;
        public JobsService(JobsRepository repo)
        {
            _repo = repo;
        }

        internal Job Create(Job newJob)
        {
            Job exists = _repo.CheckForExistingJob(newJob);
            if (exists != null)
            {
                throw new Exception("Job already exists");
            }
            return _repo.Create(newJob);
        }

        internal Job Get(int id)
        {
            Job foundJob = _repo.Get(id);
            if (foundJob == null)
            {
                throw new Exception("Invalid Id");
            }
            return foundJob;
        }

        internal void Delete(int id)
        {
            Get(id);
            _repo.Delete(id);
        }

        internal List<CompanyJobViewModel> GetByCompanyId(int id)
        {
            return _repo.GetByCompanyId(id);
        }

        internal List<ContractorJobViewModel> GetByContractorId(int id)
        {
            return _repo.GetByContractorId(id);
        }
    }
}