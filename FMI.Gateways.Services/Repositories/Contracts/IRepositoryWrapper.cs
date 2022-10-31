namespace FMI.Gateways.Services.Repositories.Contracts
{
    public interface IRepositoryWrapper
    {
        IGatewayRepository Gateway { get; }
        IPeripherialDeviceRepository PeripherialDevice { get; }

        void Save();
    }
}