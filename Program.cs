var builder = WebApplication.CreateBuilder(args);

// Configurar a porta usando a variável de ambiente PORT do Render
var port = Environment.GetEnvironmentVariable("PORT") ?? "80";
builder.WebHost.UseUrls($"http://+:{port}");

// Restante da configuração...
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<CardService>();
builder.Services.AddSingleton<MusicService>();

// CORS - Permitir o frontend acessar o backend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Habilitar Swagger em todos os ambientes (útil para verificar se o deploy funcionou)
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

// ── Endpoints ─────────────────────────────────────────

// GET /api/cards → Retorna todos os cards
app.MapGet("/api/cards", (CardService svc) =>
{
    return Results.Ok(svc.GetAll());
})
.WithName("GetAllCards")
.WithTags("Cards");

// GET /api/cards/{id} → Retorna um card pelo ID
app.MapGet("/api/cards/{id:guid}", (Guid id, CardService svc) =>
{
    var card = svc.GetById(id);
    return card is not null ? Results.Ok(card) : Results.NotFound();
})
.WithName("GetCardById")
.WithTags("Cards");

// GET /api/cards/status/{status} → Retorna cards filtrados por status
app.MapGet("/api/cards/status/{status}", (string status, CardService svc) =>
{
    var cards = svc.GetByStatus(status);
    return Results.Ok(cards);
})
.WithName("GetCardsByStatus")
.WithTags("Cards");

// POST /api/cards → Cria um novo card
app.MapPost("/api/cards", (Card card, CardService svc) =>
{
    var created = svc.Add(card);
    return Results.Created($"/api/cards/{created.Id}", created);
})
.WithName("CreateCard")
.WithTags("Cards");

// PUT /api/cards/{id} → Atualiza um card existente
app.MapPut("/api/cards/{id:guid}", (Guid id, Card updated, CardService svc) =>
{
    var card = svc.Update(id, updated);
    return card is not null ? Results.Ok(card) : Results.NotFound();
})
.WithName("UpdateCard")
.WithTags("Cards");

// PATCH /api/cards/{id}/move → Move um card para outra coluna
app.MapPatch("/api/cards/{id:guid}/move", (Guid id, MoveRequest request, CardService svc) =>
{
    // Status válidos
    string[] validStatuses = { "Backlog", "ToDo", "Doing", "Testing", "Done" };

    if (!validStatuses.Contains(request.Status, StringComparer.OrdinalIgnoreCase))
    {
        return Results.BadRequest(new
        {
            error = "Status inválido",
            validStatuses
        });
    }

    var card = svc.MoveCard(id, request.Status);
    return card is not null ? Results.Ok(card) : Results.NotFound();
})
.WithName("MoveCard")
.WithTags("Cards");

// DELETE /api/cards/{id} → Remove um card
app.MapDelete("/api/cards/{id:guid}", (Guid id, CardService svc) =>
{
    return svc.Delete(id) ? Results.NoContent() : Results.NotFound();
})
.WithName("DeleteCard")
.WithTags("Cards");

// Gets MusicService
app.MapGet("/api/artists", (MusicService ms) =>
{
    return Results.Ok(ms.GetArtists());
})
.WithName("GetAllArtists")
.WithTags("Musics");

app.MapGet("/api/artists/{artistId:guid}", (Guid artistId, MusicService ms) =>
{
    return Results.Ok(ms.GetArtistById(artistId));
})
.WithName("GetArtist")
.WithTags("Musics");


// Post artist
app.MapPost("/api/artists", (Artist artist, MusicService ms) =>
{

    var created = ms.AddArtist(artist);
    return Results.Created($"/api/artists/{created?.Id}", created);
})
.WithName("AddArtist")
.WithTags("Musics");

// Get Music MusicService
app.MapGet("/api/artists/musics", (MusicService ms) =>
{
    return Results.Ok(ms.GetAllMusicsWithArtists());
})
.WithName("GetAllMusics")
.WithTags("Musics");

app.MapGet("/api/artists/music/{musicId:guid}", (Guid musicId, MusicService ms) =>
{
    var music = ms.GetMusicById(musicId);
    return music is not null ? Results.Ok(music) : Results.NotFound();
})
.WithName("GetMusicById")
.WithTags("Musics");

// Put Music MusicService

app.MapPut("/api/artists/music", (Music music, MusicService ms) =>
{
    var musicUpdated = ms.UpdateMusicForAllArtists(music);
    return musicUpdated is true ? Results.Ok(ms.GetMusicById(music.Id)) : Results.NotFound();
})
.WithName("UpdateMusic")
.WithTags("Musics");

// Post MusicService
app.MapPost("/api/artists/{artistId:guid}/music", (Guid artistId, Music music, MusicService ms) =>
{
    //var created = ms.AddSongToArtist(artistId, music);
    var ( success, message, musica) = ms.AddSongToArtist(artistId, music);
    if (!success)
    {
        // Pega a mensagem que veio do Service e joga no BadRequest
        return Results.BadRequest(new { aviso = message });
    }

    return Results.Ok(new { mensagem = message, dados = musica });
    //return Results.Created($"/api/artists/music/{created?.Id}", created);
})
.WithName("CreateMusic")
.WithTags("Musics");

// Delete Artist

app.MapDelete("/api/artists/{artistId:guid}", (Guid artistId, MusicService ms) =>
{
    return ms.DeleteArtist(artistId) ? Results.NoContent() : Results.NotFound();
})
.WithName("DeleteArtist")
.WithTags("Musics");

// Delete Music

app.MapDelete("/api/artists/music/{musicId:guid}", (Guid musicId, MusicService ms) =>
{
    return ms.DeleteMusic(musicId) ? Results.NoContent() : Results.NotFound();
})
.WithName("DeleteMusic")
.WithTags("Musics");

app.Run();

// ── Records auxiliares ────────────────────────────────
// Record usado para receber o novo status no endpoint de mover card
public record MoveRequest(string Status);
