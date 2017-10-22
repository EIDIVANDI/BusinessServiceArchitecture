using System;
using BusinessServiceArchitecture_Data;
using BusinessServiceArchitecture_Repository;
using BusinessServiceArchitecture_Domain.User;
using BusinessServiceArchitecture_Domain;

namespace BusinessServiceArchitecture_Servic.Generic
{
    public class GenericService : IGenericService
    {
        private IGenericRepository<BaseEntity> _Repository;

        public GenericService()
            :this(new GenericRepository<BaseEntity, EntityContext>())
        { }
        public GenericService(IGenericRepository<BaseEntity> repository)
        {
            this._Repository = repository;
        }

        public DomainBaseEntity GetItem(int id)
        {
            BaseEntity entity = _Repository.GetSingle(i => i.Id == id);
            if (entity != null)
            {
                return new DomainBaseEntity
                {
                    Id = entity.Id
                };
            }
            return null;
        }
    }
}