using HospitalCRM.Interfaces;
using HospitalCRM.Models;
using Newtonsoft.Json;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace HospitalCRM.Service;

public class BemorService : IBemorService
{
    private string FilePath = Path.PATH_DB_BEMOR_TXT;
    private long LastId = 0;
    public BemorService()
    {

        string source = File.ReadAllText(FilePath);
        if (string.IsNullOrEmpty(source))
            File.WriteAllText(FilePath, "[]");
    }
    public Bemor Create(Bemor bemor)
    {
        string source = File.ReadAllText(FilePath);
        List<Bemor> bemorlar = JsonConvert.DeserializeObject<List<Bemor>>(source);
        Bemor existBemor = bemorlar.FirstOrDefault(u => u.Id.Equals(bemor.Id));
        if (existBemor is not null)
            return null;
        bemorlar.Add(bemor);
        string json = JsonConvert.SerializeObject(bemorlar, Formatting.Indented);
        File.WriteAllText(FilePath, json);
        return bemor;
    }

    public List<Bemor> GetAll()
    {
        string source = File.ReadAllText(FilePath);
        return JsonConvert.DeserializeObject<List<Bemor>>(source);
    }

    public Bemor GetById(long id)
        => GetAll().FirstOrDefault(u => u.Id.Equals(id));

    public Bemor Update(Bemor bemor)
    {

        List<Bemor> bemorlar = GetAll();
        Bemor existBemor = bemorlar.FirstOrDefault(u => u.Id.Equals(bemor.Id));
        if (existBemor is not null)
        {
            return null;
        }
        existBemor.Id = bemor.Id;
        existBemor.FirstName = existBemor.FirstName;
        existBemor.LastName = existBemor.LastName;
        existBemor.Age = existBemor.Age;
        existBemor.Diagnoz= existBemor.Diagnoz;
        existBemor.RegestratsiyaVaqti = existBemor.RegestratsiyaVaqti;
        string json = JsonConvert.SerializeObject(bemorlar, Formatting.Indented);
        return bemor;
    }

    bool IBemorService.Delete(long id)
    {
        List<Bemor> bemorlar = GetAll();
        Bemor existBemor = bemorlar.FirstOrDefault(u => u.Id.Equals(id));
        if (existBemor is null)
        {
            return false;
        }
        bemorlar.Remove(existBemor);
        string json = JsonConvert.SerializeObject(bemorlar, Formatting.Indented);
        return true;
    }
}
