using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Spiralfy.Core.Interfaces;
using SpotifyAPI.Web;

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
            return (await _spotify.Player.GetCurrentlyPlaying(new PlayerCurrentlyPlayingRequest()))?.Item;
        }

        public async Task Next() => await _spotify.Player.SkipNext();

        public async Task Previous() => await _spotify.Player.SkipPrevious();

        public async Task Play() => await _spotify.Player.ResumePlayback();

        public async Task Play(IPlayableItem item)
        {
            var uri = item switch
            {
                FullTrack t => t.Uri,
                FullEpisode e => e.Uri,
                _ => throw new ArgumentException("item has no valid Uri")
            };

            var req = new PlayerResumePlaybackRequest
            {
                Uris = new List<string> { uri }
            };
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
            return !playing;
        }

        public async Task<bool> IsPlaying()
        {
            var pb = await _spotify.Player.GetCurrentPlayback();
            return pb?.IsPlaying ?? false;
        }
    }
}
