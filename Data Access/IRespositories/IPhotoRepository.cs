using Housing_Society.Models;

namespace Housing_Society.Data_Access
{
    public interface IPhotoRepository
    {
        public Task AddPhotos(List<Photo> photos);
    }
}
