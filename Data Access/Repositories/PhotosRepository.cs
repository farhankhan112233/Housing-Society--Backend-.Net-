using Housing_Society.Models;

namespace Housing_Society.Data_Access
{
    public class PhotosRepository : IPhotoRepository
    {
        private readonly HousingSocietyContext dbContext;

        public PhotosRepository(HousingSocietyContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddPhotos(List<Photo> photos)
        {
            if (photos == null || !photos.Any())
            {
                throw new Exception("Photos not provided");
            }

            await dbContext.Photos.AddRangeAsync(photos);

            
        }
    }
}
