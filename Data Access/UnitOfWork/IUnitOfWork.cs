namespace Housing_Society.Data_Access.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IHouseRepository houseRepository { get; }
        IStateRepository stateRepository { get; }
        IPhotoRepository photoRepository { get; }
        ICityRepository  cityRepository { get; }
        public Task<int>  Complete();
        
    }
}
