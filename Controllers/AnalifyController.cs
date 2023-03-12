using Analify.Dto;
using Analify.Service;
using Microsoft.AspNetCore.Mvc;

namespace Analify.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnalifyController:ControllerBase
    {
        private readonly ILogger<AnalifyController> _logger;
        private readonly IConfiguration _configuration;
        public AnalifyController(ILogger<AnalifyController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        [HttpGet("track/{term}")]
        public TrackResponseDTO GetTrack(string term)
        {
            SpotifyService spotifyService = new SpotifyService(_configuration);
            
            return spotifyService.getTracks(term);
        }
    }
}
