using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contractor.Models;
using contractor.Repositories;

namespace contractor.Services
{
    public class ContractorsService
    {
        private readonly ContractorsRepository _repo;
        public ContractorsService(ContractorsRepository repo)
        {
            _repo = repo;
        }

        internal List<Contractor> Get()
        {
           return _repo.Get();
        }
        internal Contractor Get(int id)
        {
            Contractor foundContractor = _repo.Get(id);
            if (foundContractor == null)
            {
                throw new Exception("Invalid Id");
            }
            return foundContractor;
        }

     

        internal Contractor Create(Contractor contractor)
        {
            Contractor newContractor = _repo.Create(contractor);
            return newContractor;
        }

        internal Contractor Edit(int id, Contractor contractor)
        {
            throw new NotImplementedException();
        }

        internal Contractor Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}