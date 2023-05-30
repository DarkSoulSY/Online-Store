

using DataAccessLayer.Models;
using DataAccessLayer.Repositories.WrapperRepo;

namespace Services.Services.PictureServices
{
    public class PictureService : IPictureService
    {
        private readonly IRepositoryWrapper _wrapper;

        public PictureService(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }
        public async Task<ServiceResponse<List<Picture>?>> GetAllPictures()
        {
            var pictures = await _wrapper.Picture.GetAllPictures();

            if (pictures is not null)
            {
                return new ServiceResponse<List<Picture>?>()
                {
                    Data = pictures, 
                    Message = "Retrieved all pictures successfully!",
                    Success = true,
                };
            }
            else
                return new ServiceResponse<List<Picture>?>()
                {
                    Data = null,
                    Message = "Could not find any pictures!",
                    Success = false,
                };
        }
    }
}
