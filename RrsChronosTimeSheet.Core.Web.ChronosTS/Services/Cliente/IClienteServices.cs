using RrsChronosTimeSheet.Core.Web.ChronosTS.Data.ViewModel;

namespace RrsChronosTimeSheet.Core.Web.ChronosTS.Services.Cliente
{
    public interface IClienteServices
    {
        public Task<IEnumerable<ClienteViewModel>> GetAllClientesAsync(CancellationToken cancellationToken);

        public Task<ClienteViewModel?> GetClienteByIdAsync(Guid id, CancellationToken cancellationToken);

        public Task<IEnumerable<ClienteViewModel>> GetClientesByUFAsync(Guid ufId, CancellationToken cancellationToken);

        public Task<ClienteViewModel> CreateClienteAsync(ClienteViewModel clienteViewModel, CancellationToken cancellationToken);

        public Task<ClienteViewModel> UpdateClienteAsync(Guid id, ClienteViewModel clienteViewModel, CancellationToken cancellationToken);

    }
}
