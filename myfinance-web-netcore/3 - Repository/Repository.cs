
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;

namespace myfinance_web_netcore.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
    {

        protected DbContext Db;
        protected DbSet<TEntity> DbSetContext;

        protected Repository(DbContext dbContext)
        {
            Db = dbContext;
            DbSetContext = Db.Set<TEntity>();
        }

        public void Cadastrar(TEntity Entidade)
        {
            if (Entidade.Id == null) {
                DbSetContext.Add(Entidade);
            } 
            else {
                Db.Attach(Entidade); 
                Db.Entry(Entidade).State = EntityState.Modified; 
            }

            Db.SaveChanges();
        }

        public void Excluir(int id)
        {
            var entidade = new TEntity() { Id = id };

            Db.Attach(entidade);
            Db.Remove(entidade);
            Db.SaveChanges();
        }

        public List<TEntity> ListarRegistros()
        {
            return DbSetContext.ToList();
        }

        public TEntity RetornarRegistro(int? id)
        {
            return DbSetContext.Where(x => x.Id == id).First();
        }
    }
}