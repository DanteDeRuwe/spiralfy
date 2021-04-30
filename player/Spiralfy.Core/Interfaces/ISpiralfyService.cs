using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyAPI.Web;

namespace Spiralfy.Core.Interfaces
{
    public interface ISpiralfyService
    {
        public Task<PrivateUser> GetCurrentUser();
        public Task<FullTrack> GetTrack(string trackId);
        public Task<Device> GetActiveDevice();
        public Task<IReadOnlyCollection<SimplePlaylist>> GetUserPlaylists();
    }
}
