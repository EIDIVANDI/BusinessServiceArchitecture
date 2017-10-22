using BusinessServiceArchitecture_Domain;
using BusinessServiceArchitecture_Domain.User;

namespace BusinessServiceArchitecture_Servic.Generic
{
    public interface IGenericService
    {
        DomainBaseEntity GetItem(int id);
    }
}