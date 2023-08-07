using HospitalCRM.Models;

namespace HospitalCRM.Interfaces;

public interface IBemorService
{
    Bemor Create(Bemor bemor);
    Bemor Update(Bemor bemor);
    bool Delete(long id);
    Bemor GetById(long id);
    List<Bemor> GetAll();

}
