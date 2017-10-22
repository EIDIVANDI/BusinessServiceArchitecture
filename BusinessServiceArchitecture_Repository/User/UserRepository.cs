namespace BusinessServiceArchitecture_Repository.User
{
    using System.Collections.Generic;
    using BusinessServiceArchitecture_Data;
    using BusinessServiceArchitecture_Data.DataEntities;
    using System.Data.Entity;
    using System.Linq;
    using System;
    using System.Linq.Expressions;

    public class UserRepository : GenericRepository<User, EntityContext>, IUserRepository
    {
        public IEnumerable<Order> OrdersHistory(User user)
        {
            return OrdersHistory(user.Id);
        }

        public IEnumerable<Order> OrdersHistory(Expression<Func<User, bool>> predicate)
        {
            return Query(predicate).Where(u=>u.IsActive).Include(o => o.Orders).SingleOrDefault().Orders.AsEnumerable();
        }

        public IEnumerable<Order> OrdersHistory(string userId)
        {
            return OrdersHistory(int.Parse(userId));
        }

        public IEnumerable<Order> OrdersHistory(int userId)
        {
            return OrdersHistory(u => u.Id == userId);
        }
    }
}