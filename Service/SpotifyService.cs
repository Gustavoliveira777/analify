using Analify.Dto;
using SpotifyAPI.Web;
using System.Text;

namespace Analify.Service
{
    public class SpotifyService
    {
        private readonly IConfiguration _configuration;
        public SpotifyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TrackResponseDTO getTracks(string term)
        {
            var config = SpotifyClientConfig.CreateDefault().WithAuthenticator(new ClientCredentialsAuthenticator(_configuration.GetValue<string>("SpotifyConnect:clientId"), _configuration.GetValue<string>("SpotifyConnect:clientSecret")));

            var spotify = new SpotifyClient(config);
            var searchResults = spotify.Search.Item(new SearchRequest(SearchRequest.Types.Track, term));

            var tracks = searchResults.Result.Tracks;
            return new TrackResponseDTO(tracks.Items.Select(it =>
            {
                List<SimpleArtist> artistas = it.Artists;
                StringBuilder sb = new StringBuilder();
                artistas.ForEach(art =>
                {
                    sb.Append(art.Name).Append(" ");
                });
                return new Model.Track(it.Name, sb.ToString(), it.DurationMs.ToString(), it.Popularity.ToString());
            }).ToList());
        }

    }
}
