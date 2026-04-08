var builder = WebApplication.CreateBuilder(args);

// ── Serviços ──────────────────────────────────────────
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<CardService>();
builder.Services.AddSingleton<MusicService>();

// ── CORS (permite o frontend se conectar) ─────────────
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// ── Middlewares ────────────────────────────────────────
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();

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

app.MapGet("/api/artists/musics", (MusicService ms) =>
{
    return Results.Ok(ms.GetAllMusicsWithArtists());
})
.WithName("GetAllMusics")
.WithTags("Musics");

app.MapGet("/api/artists/music/{musicId:guid}", (Guid musicId, MusicService ms) =>
{
    return Results.Ok(ms.GetMusicById(musicId));
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
    var created = ms.AddSongToArtist(artistId, music);
    return Results.Created($"/api/artists/{artistId}/music/{created?.Id}", created);
})
.WithName("CreateMusic")
.WithTags("Musics");

app.Run();

// ── Records auxiliares ────────────────────────────────
// Record usado para receber o novo status no endpoint de mover card
public record MoveRequest(string Status);
