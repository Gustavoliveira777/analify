using Analify.Model;
using SpotifyAPI.Web;

namespace Analify.Dto
{
    public class TrackResponseDTO
    {
        public TrackResponseDTO(List<Track> tracks)
        {
            this.tracks = tracks;
        }
        public List<Track> tracks { get; set; }
    }
}
