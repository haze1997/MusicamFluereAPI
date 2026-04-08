public class Artist
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string UrlImage { get; set; } = string.Empty;
    public List<Music> Musics { get; set; } = new List<Music>();
}
