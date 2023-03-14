namespace Analify.Model
{
    public class Track
    {
        public Track(string name,string author, string duration, string ranking,string uri) { 
            this.name = name;
            this.author = author;
            this.duration = duration;
            this.ranking = ranking;
            this.uri = uri;
        }
        public string name {  get; set; }
        public string author { get; set; }
        public string duration { get; set; }
        public string ranking { get; set; }
        public string uri { get; set; }
    }
}