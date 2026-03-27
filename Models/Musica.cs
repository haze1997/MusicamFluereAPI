public class Musica
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Lyrics { get; set; } = string.Empty;
    public string Artist { get; set; } = string.Empty;
    public string LinkYoutube { get; set; } = string.Empty; // link do vídeo da música no Youtube
    public string Genre { get; set; } = "Pop";  // Rock, Pop, Reggae
    public bool Cover { get; set; } = false;    // true, false
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
