using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contractor.Models;
using contractor.Repositories;

namespace contractor.Services
{
    public class CompaniesService
    {
        private readonly CompaniesRepository _repo;
        public CompaniesService(CompaniesRepository repo)
        {
            _repo = repo;
        }

        internal List<Company> Get()
        {
            return _repo.Get();
        }

        internal Company Get(int id)
        {
            Company foundCompany = _repo.Get(id);
            if (foundCompany == null)
            {
                throw new Exception("Invalid Id");
            }
            return foundCompany;
        }

        internal Company Create(Company company)
        {
            Company newCompany = _repo.Create(company);
            return newCompany;
        }

        internal Company Edit(int id, Company company)
        {
            throw new NotImplementedException();
        }

        internal Company Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}