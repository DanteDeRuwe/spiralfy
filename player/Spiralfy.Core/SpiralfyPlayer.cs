using Spiralfy.Core.Interfaces;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spiralfy.Core
{
    public class SpiralfyPlayer : ISpiralfyPlayer
    {
        private readonly ISpotifyClient _spotify;

        public SpiralfyPlayer(ISpotifyClient spotify)
        {
            _spotify = spotify;
        }

        public async Task<IPlayableItem> GetCurrentlyPlaying()
        {
            return(await _spotify.Player.GetCurrentlyPlaying(new PlayerCurrentlyPlayingRequest()))?.Item;
        }

        public async Task Next() => await _spotify.Player.SkipNext();

        public async Task Previous() => await _spotify.Player.SkipPrevious();
        
        public async Task<FullPlaylist> GetCurrentPlaylist()
        {
            var playback = await _spotify.Player.GetCurrentPlayback();
            var playlistUri = playback?.Context?.Uri?.Split(':')?.Last();
            if (playlistUri is null) return null;
            return await _spotify.Playlists.Get(playlistUri);
        }

        public async Task Play() => await _spotify.Player.ResumePlayback();

        public async Task Play(IPlayableItem item)
        {
            var uri = GetUri(item);

            var req = new PlayerResumePlaybackRequest
            {
                Uris = new List<string> { uri }
            };
            await _spotify.Player.ResumePlayback(req);
        }

        private static string GetUri(IPlayableItem item)
        {
            return item switch
            {
                FullTrack t => t.Uri,
                FullEpisode e => e.Uri,
                _ => throw new ArgumentException("item has no valid Uri")
            };
        }

        public async Task PlayShuffle(SimplePlaylist playlist)
        {
            var req = new PlayerResumePlaybackRequest
            {
                ContextUri = playlist.Uri
            };
            try
            {
                await _spotify.Player.SetShuffle(new PlayerShuffleRequest(true));
            }
            catch { }
            await _spotify.Player.ResumePlayback(req);
        }

        public async Task Pause() => await _spotify.Player.PausePlayback();

        public async Task<bool> PlayPause()
        {
            var playing = await IsPlaying();
            if (playing)
            {
                await Pause();
            }
            else
            {
                await Play();
            }

            return!playing;
        }

        public async Task<bool> IsPlaying()
        {
            var pb = await _spotify.Player.GetCurrentPlayback();
            return pb?.IsPlaying ?? false;
        }
    }
}
