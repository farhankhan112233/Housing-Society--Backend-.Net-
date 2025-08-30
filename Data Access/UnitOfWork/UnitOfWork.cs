using Housing_Society.Models;

namespace Housing_Society.Data_Access.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HousingSocietyContext _context;
        public ICityRepository cityRepository { get; }
        public IStateRepository stateRepository { get; }
        public IHouseRepository houseRepository { get; }
        public IPhotoRepository photoRepository { get; }
        public UnitOfWork(HousingSocietyContext context, ICityRepository cityRepository, IStateRepository stateRepository, IHouseRepository houseRepository, IPhotoRepository photoRepository)
        {
            _context = context;
            this.cityRepository = cityRepository;
            this.stateRepository = stateRepository;
            this.houseRepository = houseRepository;
            this.photoRepository = photoRepository;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
