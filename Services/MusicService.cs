public class MusicService
{
    // Listas em memória para simular o armazenamento
    private readonly List<Artist> _artists = new();

    public MusicService()
    {
        SeedArtist();
    }

    /// <summary>
    /// Dados iniciais para o board não começar vazio
    /// </summary>
    private void SeedArtist()
    {
        _artists.AddRange(new List<Artist>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Jhon Lennon",
                UrlImage = "image_do_jhon_lennon"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Jimmy Hendrix",
                UrlImage = "https://www.rollingstone.com/wp-content/uploads/2018/06/rs-197621-84894709.jpg?w=1581&h=1054&crop=1",
                Musics = new List<Music>{
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Little Wing",
                        Lyrics = """
                        Well, she's walking through the clouds
                        With a circus mind
                        That's running round
                        Butterflies and zebras and moonbeams
                        And fairy Tales

                        That's all she ever thinks about

                        Riding with the wind

                        When I'm sad, she comes to me
                        With a thousand smiles
                        She gives to me free

                        It's alright, she said
                        It's alright
                        Take anything you want from me
                        You can take anything, anything

                        Fly on, little wing
                        Yeah, yeah, yeah, little wing
                        """,
                        LinkYoutube = "https://www.youtube.com/watch?v=35luFxHO5E0", // link do vídeo da música no Youtube
                        Genre = "Rock",  // Rock, Pop, Reggae
                        Cover  = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                }

            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Metallica",
                UrlImage = "image_do_metallica"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Matt Simons",
                UrlImage = "image_do_matt_simons"
            }
        });
    }

    // Contadores para simular o auto-incremento do banco de dados
    //private int _nextArtistId = 1;
    //private int _nextSongId = 1;
    //
    // ── CRUD ──────────────────────────────────────────────

    public List<Artist> GetArtists() => _artists;

    /*public List<Artist> GetArtists()
    {
        return _artists;
    }*/

    public Artist AddArtist(Artist artist)
    {
        artist.Id = Guid.NewGuid();
        _artists.Add(artist);
        return artist;
    }

    public bool UpdateMusicForAllArtists(Music updatedMusic)
    {
        // 1. Usa o SelectMany para achatar as listas e o Where para filtrar
        // apenas as músicas que têm o mesmo Id da música que queremos atualizar.
        var musicsToUpdate = _artists
            .SelectMany(a => a.Musics)
            .Where(m => m.Id == updatedMusic.Id)
            .ToList(); // Materializa a lista de referências encontradas

        // Se a lista estiver vazia, significa que nenhum artista tem essa música
        if (!musicsToUpdate.Any())
        {
            return false;
        }

        // 2. Percorre todas as cópias/referências dessa música encontradas
        foreach (var music in musicsToUpdate)
        {
            // Atualiza os campos necessários com os novos valores
            music.Title = updatedMusic.Title;
            music.Lyrics = updatedMusic.Lyrics;
            music.LinkYoutube = updatedMusic.LinkYoutube;
            music.Genre = updatedMusic.Genre;
            music.Cover = updatedMusic.Cover;
            music.UpdatedAt = DateTime.Now;
            // Se houver mais campos, atualize-os aqui...
        }

        return true; // Atualização concluída com sucesso
    }


    public Music? AddSongToArtist(Guid artistId, Music music)
    {
        // se a musica tem id, recupera a entidade e so adiciona ao artista se a musca nao estiver na lista dele
        // se nao tem id, ai sim, gera um guid, adiciona todos os atributos da mudica, e so depois adiciona ao artista
        // Busca artista na lista em memória
        var artist = _artists.FirstOrDefault(a => a.Id == artistId);

        if (!UpdateMusicForAllArtists(music))
            music.Id = Guid.NewGuid();

        if (artist is null || artist.Musics.Any(p => p.Id == music.Id))
            return null; // Artista não encontrado




        music.CreatedAt = DateTime.Now;
        music.UpdatedAt = DateTime.Now;
        //music.ArtistId = artistId;
        artist.Musics.Add(music);

        return music;
    }

    public object GetAllMusicsWithArtists()
    {
        var musicasAgrupadas = _artists
            .SelectMany(
                artista => artista.Musics,
                (artista, musica) => new { Musica = musica, Artista = artista }
            )
            .GroupBy(x => x.Musica.Id) // Agrupa as músicas pelo Título (ou use o Id)
            .Select(grupo => new
            {
                Id = grupo.Key, // O Key é o Título que usamos no GroupBy
                Title = grupo.First().Musica.Title,
                Lyrics = grupo.First().Musica.Lyrics,
                // Pega o nome dos artistas dentro desse grupo e aplica o Distinct
                // para não repetir o nome do artista na mesma música
                LinkYoutube = grupo.First().Musica.LinkYoutube,
                Genre = grupo.First().Musica.Genre,
                Cover = grupo.First().Musica.Cover,
                UpdatedAt = grupo.First().Musica.UpdatedAt,
                Artists = grupo.Select(x => new
                {
                    Id = x.Artista.Id, // É sempre bom retornar o Id para o Front-end!
                    Name = x.Artista.Name,
                    UrlImage = x.Artista.UrlImage
                })
                .DistinctBy(a => a.Id) // <-- Aqui você filtra as duplicatas EXCLUSIVAMENTE pelo Guid
                .ToList()
                //Artists = grupo.Select(x => x.Artista.Name).Distinct().ToList()
            })
            .ToList();

        return musicasAgrupadas;
    }

    public object? GetMusicById(Guid musicId) // 1. Recebe o ID por parâmetro (Note o 'object?' que permite retornar null)
    {
        var musicaEncontrada = _artists
            .SelectMany(
                artista => artista.Musics,
                (artista, musica) => new { Musica = musica, Artista = artista }
            )
            // 2. Filtra IMEDIATAMENTE para manter apenas a música com este ID
            .Where(x => x.Musica.Id == musicId)

            // Agrupa pelo ID (como filtramos por 1 ID, haverá apenas 1 grupo)
            .GroupBy(x => x.Musica.Id)
            .Select(grupo => new
            {
                Id = grupo.Key, // O Key agora é o ID da música
                Title = grupo.First().Musica.Title,
                Lyrics = grupo.First().Musica.Lyrics,
                LinkYoutube = grupo.First().Musica.LinkYoutube,
                Genre = grupo.First().Musica.Genre,
                Cover = grupo.First().Musica.Cover,
                UpdatedAt = grupo.First().Musica.UpdatedAt,
                // Lista de artistas que têm essa música
                Artists = grupo.Select(x => new
                {
                    Id = x.Artista.Id,
                    Name = x.Artista.Name,
                    UrlImage = x.Artista.UrlImage
                })
                .DistinctBy(a => a.Id) // Evita artistas duplicados
                .ToList()
            })
            // 3. Pega o primeiro (e único) resultado do grupo, ou retorna null se não achar nada
            .FirstOrDefault();

        return musicaEncontrada;
    }
}
