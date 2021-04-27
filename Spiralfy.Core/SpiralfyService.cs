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
    }
}
