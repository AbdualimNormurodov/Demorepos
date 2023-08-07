using HospitalCRM.Service;
using HospitalCRM.Models;

namespace HospitalCRM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BemorService bemorService = new BemorService();
            bemorService.Create(new Bemor
            {
                Id= 1,
                FirstName="aaaaaa",
                LastName="bbbbbbb",
                Age=DateTime.Now,
                Diagnoz="sdgssgfdsfs"
            });
        }
    }
}