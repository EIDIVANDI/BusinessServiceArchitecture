using System;
using BusinessServiceArchitecture_Domain;
using BusinessServiceArchitecture_Repository.User;
using BusinessServiceArchitecture_Domain.Order;

namespace BusinessServiceArchitecture_Servic.User
{
    public class UserService : IUserService
    {
        private IUserRepository _Repository;

        public UserService()
            : this(new UserRepository()) { }

        public UserService(IUserRepository repository)
        {
            this._Repository = repository;
        }

        public OrderModel GetUserLastOrderDetails(int userId)
        {
            throw new NotImplementedException();
        }
    }
}