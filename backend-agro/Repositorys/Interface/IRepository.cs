namespace backend_agro.Repositorys.Interface;
public interface IRepository<TEntity>
{
    public TEntity Get(int Id);
   
    public List<TEntity> GetAll();
   
}