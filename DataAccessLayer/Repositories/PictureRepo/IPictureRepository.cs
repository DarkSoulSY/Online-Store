using DataAccessLayer.Models;
using DataAccessLayer.Repositories.BaseRepo;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.PictureRepo
{
    public interface IPictureRepository : IRepositoryBase<Picture>
    {
        Task<List<Picture>> GetAllPictures();
        Task<Picture?> GetSinglePicture(Expression<Func<Picture, bool>> expression);
        void CreatePicture(Picture picture);
        void UpdatePicture(Picture picture);
        void DeletePicture(Picture picture);
    }
}
