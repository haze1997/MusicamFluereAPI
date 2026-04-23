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
                UrlImage = "https://akamai.sscdn.co/uploadfile/letras/fotos/d/4/d/1/d4d1305596424132afc895f590e39d97-tb4.jpg"
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
                UrlImage = "https://akamai.sscdn.co/uploadfile/letras/fotos/3/7/7/6/37761eb939e030b0d4cf2248284a4d44-tb4.jpg"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Matt Simons",
                UrlImage = "https://akamai.sscdn.co/uploadfile/letras/fotos/7/d/9/3/7d93e048e2a3e84963269ab3222b1a96-tb4.jpg",
                Musics = new List<Music>{
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Catch And Release",
                        Lyrics = """
                        There's a place I go to
                        Where no one knows me
                        It's not lonely
                        It's a necessary thing

                        It's a place I made up
                        Find out what I'm made of
                        The nights I've stayed up
                        Counting stars and fighting sleep

                        Let it wash over me
                        Ready to lose my feet
                        Take me on to the place
                        Where one reveals life's mistery

                        Steady on down the line
                        Lose every sense of time
                        Take it all in
                        And wake up that small part of me

                        Day to day I'm blind to see
                        And find how far to go

                        Everybody got their reason
                        Everybody got their way
                        We're just catching and releasing
                        What builds up throughout the day

                        It gets into your body
                        And it flows right through your blood
                        We can tell eachother secrets
                        And remember how to love

                        There's a place I'm going
                        No one knows me
                        If I breathe real slowly
                        Let it out and let it in

                        They can be terrifying
                        To be slowly dying
                        Also clarifying
                        The end where we begin

                        So let it wash over me
                        I'm ready to lose my feet
                        Take me on to the place
                        Where one reviews life's mistery

                        Steady on down the line
                        Lose every sense of time
                        Take it all in
                        And wake up that small part of me

                        Day to day I'm blind to see
                        And find how far to go

                        Everybody got their reason
                        Everybody got their way
                        We're just catching and releasing
                        What builds up throughout the day

                        It gets into your body
                        And it flows right through your blood
                        We can tell eachother secrets
                        And remember how to love

                        Everybody got their reason
                        Everybody got their way
                        We're just catching and releasing
                        What builds up throughout the day

                        And it gets into your body
                        And it flows right through your blood
                        We can tell eachother secrets
                        And remeber how to love
                        """,
                        LinkYoutube = "https://www.youtube.com/watch?v=1LXsm9y-z3I",
                        Genre = "Eletronica",
                        Cover  = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Jessé",
                UrlImage = "https://akamai.sscdn.co/letras/115x115/fotos/6/2/1/8/6218854b451b89d361af2c57c9e19dac.jpg",
                Musics = new List<Music>{
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Asas - Maskavo",
                        Lyrics = """
                        Alalauê!
                        Alalauê! Ê! Ê! Ê!
                        Alalauê!
                        Alalauê! Ê! Ê! Ê!

                        Cê parece um anjo
                        Só que não tem asas iaiá
                        Oh meu Deus!
                        Quando asas tiver
                        Passe lá em casa

                        Cê parece um anjo
                        Só que não tem asas iaiá
                        Oh meu Deus!
                        Quando asas tiver
                        Passe lá em casa

                        E ao sair
                        Pras estrelas
                        Eu vou te levar
                        Com a ajuda da brisa do mar
                        Te mostrar onde ir

                        E ao chegar
                        Apresento-lhe a lua e o Sol
                        E no céu vai ter mais um farol
                        Que é a luz do teu olhar

                        Eu não sou moleque
                        Ainda não tenho casa iaiá
                        Oh meu Deus!
                        Se um dia eu tiver
                        Visto minhas asas

                        Eu não sou moleque
                        Eu não!
                        Ainda não tenho casa iaiá
                        Oh meu Deus!
                        Se um dia eu tiver
                        Visto minhas asas

                        E ao sair
                        Pras estrelas
                        Eu vou te levar
                        Com a ajuda da brisa do mar
                        Te mostrar onde ir

                        E ao chegar
                        Apresento-lhe a lua e o Sol
                        E no céu vai ter mais um farol
                        Que é a luz do teu olhar

                        Cê parece um anjo
                        Só que não tem asas iaiá
                        Oh meu Deus!
                        Quando asas tiver
                        Passe lá em casa

                        Cê parece um anjo
                        Só que não tem asas iaiá
                        Oh meu Deus!
                        Quando asas tiver
                        Passe lá em casa

                        E ao sair
                        Pras estrelas
                        Eu vou te levar
                        Com a ajuda da brisa do mar
                        Te mostrar onde ir

                        E ao chegar
                        Apresento-lhe a lua e o Sol
                        E no céu vai ter mais um farol
                        Que é a luz do teu olhar

                        Alalauê!
                        Alalauê! Ê! Ê! Ê!
                        Alalauê!
                        Alalauê! Ê! Ê! Ê!

                        Alalauê!
                        Alalauê! Ê! Ê! Ê!
                        Alalauê!
                        Alalauê! Ê! Ê! Ê!

                        Oh Lalauê! (Oh Lalauê!)
                        Oh Lalauê! Ê! Ê! Ê!
                        Oh Lalauê! (Oh Lalauê!)
                        Oh Lalauê! Ê! Ê! Ê!
                        """,
                        LinkYoutube = "https://www.youtube.com/watch?v=YETq_Zrar_g",
                        Genre = "Reggae",
                        Cover  = true,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Curtindo A Night",
                        Lyrics = """
                        Tava na night, só curtindo o flow
                        Só de boa no ritmo dos beats
                        Quando avisto a mina que também tava no fluxo
                        Ela tá dançando e olhando pra mim

                        Será que ela tem algum interesse em mim?
                        Será que ela vai aceitar sair comigo?
                        O que é que eu posso oferecer?
                        O que é que eu faço para ela me querer?

                        Se eu mostro o meu Porsche com certeza ela vem
                        Quero ver ela sair comigo de Hyundai
                        Muitos podem dizer que não tem nada a ver
                        Mas eu quero ver na hora de escolher
                        """,
                        LinkYoutube = "https://www.youtube.com/watch?v=tjOs5ctjMnM",
                        Genre = "Reggae",
                        Cover = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Maskavo",
                UrlImage = "https://akamai.sscdn.co/letras/115x115/fotos/2/0/f/1/20f129e6d33dc93ccb9875d3a48d8295.jpg"
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

    public Artist? GetArtistById(Guid id) => _artists.FirstOrDefault(c => c.Id == id);

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


    public (bool success, string message, Music? music) AddSongToArtist(Guid artistId, Music music)
    {
        // se a musica tem id, recupera a entidade e so adiciona ao artista se a musca nao estiver na lista dele
        // se nao tem id, ai sim, gera um guid, adiciona todos os atributos da mudica, e so depois adiciona ao artista
        // Busca artista na lista em memória
        var artist = _artists.FirstOrDefault(a => a.Id == artistId);

        if (!UpdateMusicForAllArtists(music))
            music.Id = Guid.NewGuid();

        if (artist is null)
            return (false, "Artista não existe!", null);
        //return null; // Artista não encontrado

        if(artist.Musics.Any(p => p.Id == music.Id))
            return (false, "Música atualizada, mas o Artista já possui a música.", null);



        music.CreatedAt = DateTime.Now;
        music.UpdatedAt = DateTime.Now;
        //music.ArtistId = artistId;
        artist.Musics.Add(music);

        //return music;
        return (true, "Música adicionada ao artista com sucesso!", music);
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

    public bool UpdateMusicGenre(Guid musicId, string newGenre)
    {
        // 1. Achata as listas e filtra para encontrar todas as referências da música nos artistas
        var musicsToUpdate = _artists
            .SelectMany(a => a.Musics)
            .Where(m => m.Id == musicId)
            .ToList();

        // Se a lista estiver vazia, a música não pertence a ninguém (ou não existe)
        if (!musicsToUpdate.Any())
        {
            return false;
        }

        // 2. Percorre as cópias da música encontradas
        foreach (var music in musicsToUpdate)
        {
            // Altera para o novo Gênero recebido do drag and drop
            music.Genre = newGenre;
            // Atualiza a data de modificação
            music.UpdatedAt = DateTime.Now;
        }

        return true; // Atualização concluída com sucesso
    }


    public bool DeleteArtist(Guid artistId)
    {
        var artist = _artists.FirstOrDefault(c => c.Id == artistId);
        if (artist is null) return false;
        _artists.Remove(artist);
        return true;
    }

    public bool DeleteMusic(Guid musicId)
    {
        bool foiDeletadaDeAlguem = false;

            // Percorre todos os artistas da lista principal
            foreach (var artist in _artists)
            {
                // Se a lista de músicas for nula, pula para o próximo artista
                if (artist.Musics == null) continue;

                // O RemoveAll deleta todos os itens que batem com a condição e retorna a quantidade deletada
                int quantidadeRemovida = artist.Musics.RemoveAll(m => m.Id == musicId);

                // Se removeu de pelo menos um artista, marcamos como sucesso
                if (quantidadeRemovida > 0)
                {
                    foiDeletadaDeAlguem = true;
                }
            }

            // Retorna true se a música existia e foi deletada de pelo menos um artista, ou false se não foi encontrada em nenhum
            return foiDeletadaDeAlguem;
    }
}
