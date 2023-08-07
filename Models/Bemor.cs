namespace HospitalCRM.Models;

public class Bemor
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Age { get; set; }
    public string Diagnoz { get; set; }
    public DateTime RegestratsiyaVaqti { get; set; } = DateTime.Now;

}
