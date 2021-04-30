using System.Threading.Tasks;
using SpotifyAPI.Web;

namespace Spiralfy.Core.Interfaces
{
    public interface ISpiralfyPlayer
    {
        public Task Play();
        public Task Play(IPlayableItem item);
        public Task PlayShuffle(SimplePlaylist playlist);
        public Task Pause();
        public Task<bool> PlayPause();
        public Task<bool> IsPlaying();
        public Task<IPlayableItem> GetCurrentlyPlaying();
        public Task Next();
        public Task Previous();
    }
}
