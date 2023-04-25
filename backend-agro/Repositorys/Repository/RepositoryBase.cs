using backend_agro.Repositorys.Entity;
using backend_agro.Repositorys.Interface;

namespace backend_agro.Repositorys.Repository;

//Utilizei o Repository pattern por facilitar o acesso a base de dados, porem por ser um JSON fiz algumas modificações
public abstract class RepositoryBase<T> : IRepository<T> where T : TEntity
{
    const string PATH_JSON = @"..\books.json";
    protected string json = "";

    public RepositoryBase()
    {
        using StreamReader reader = new(PATH_JSON);
        json = reader.ReadToEnd();
    }

    public T Get(int Id) => GetAll().SingleOrDefault(x=>x.Id == Id);
   
    public abstract List<T> GetAll();
}
