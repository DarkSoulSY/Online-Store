using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.PictureRepo
{
    public class PictureRepository : RepositoryBase<Picture>, IPictureRepository
    {
        public PictureRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            
        }
        public void CreatePicture(Picture picture)
        {
            Create(picture);
        }

        public void DeletePicture(Picture picture)
        {
            Delete(picture);
        }

        public async Task<List<Picture>> GetAllPictures()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Picture?> GetSinglePicture(Expression<Func<Picture, bool>> expression)
        {
            return await FindByCondition(expression).SingleOrDefaultAsync();
        }

        public void UpdatePicture(Picture picture)
        {
            Update(picture);
        }
    }
}
