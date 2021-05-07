using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spiralfy.Core.Interfaces;
using Spiralfy.Core.Utils;
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

        public async Task<bool> IsFavorite(IPlayableItem item)
        {
            var ids = new[] { item.GetId() };
            return (await _spotify.Library.CheckTracks(new LibraryCheckTracksRequest(ids))).FirstOrDefault();
        }

        
        public async Task<bool> ToggleFavorite(IPlayableItem item)
        {
            return item switch
            {
                FullTrack track => await ToggleFavorite(track),
                FullEpisode episode => await ToggleFavorite(episode),
                _ => false
            };
        }
        
        private async Task<bool> ToggleFavorite(FullTrack track)
        {
            var ids = new[] { track.Id };
            var isFavorite = await IsFavorite(track);
            if (isFavorite)
            {
                await _spotify.Library.RemoveTracks(new LibraryRemoveTracksRequest(ids));
            }
            else
            {
                await _spotify.Library.SaveTracks(new LibrarySaveTracksRequest(ids));
            }
            return !isFavorite;
        }        
        
        private async Task<bool> ToggleFavorite(FullEpisode episode)
        {
            var ids = new[] { episode.Show.Id };
            var isFavorite = (await _spotify.Library.CheckShows(new LibraryCheckShowsRequest(ids))).FirstOrDefault();
            if (isFavorite)
            {
                await _spotify.Library.RemoveShows(new LibraryRemoveShowsRequest(ids));
            }
            else
            {
                await _spotify.Library.SaveShows(new LibrarySaveShowsRequest(ids));
            }
            return !isFavorite;
        }
    }
}
