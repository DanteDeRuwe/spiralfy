using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spiralfy.Core.Interfaces;
using SpotifyAPI.Web;

namespace Spiralfy.Core
{
    public class SpiralfyService : ISpiralfyService
    {
        private readonly ISpotifyClient _spotify;
        
        public SpiralfyService(ISpotifyClient spotify)
        {
            _spotify = spotify;
        }

        public Task<PrivateUser> GetCurrentUser()
        {
            return _spotify.UserProfile.Current();
        }

        public Task<FullTrack> GetTrack(string trackId)
        {
            return _spotify.Tracks.Get(trackId);
        }

        public async Task<Device> GetActiveDevice()
        {
            return (await _spotify.Player.GetAvailableDevices()).Devices.SingleOrDefault(d => d.IsActive);
        }

        public async Task<IReadOnlyCollection<SimplePlaylist>> GetUserPlaylists()
        {
            return (await _spotify.Playlists.CurrentUsers(new PlaylistCurrentUsersRequest() { Limit = 50 })).Items;
        }
    }
}
