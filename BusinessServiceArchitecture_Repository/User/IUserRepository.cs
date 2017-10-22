namespace BusinessServiceArchitecture_Repository.User
{
    using BusinessServiceArchitecture_Data;
    using BusinessServiceArchitecture_Data.DataEntities;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IUserRepository:IGenericRepository<User>
    {
        IEnumerable<Order> OrdersHistory(Expression<Func<User, bool>> predicate);
        IEnumerable<Order> OrdersHistory(string userId);
        IEnumerable<Order> OrdersHistory(User user);
        IEnumerable<Order> OrdersHistory(int userId);

    }
}