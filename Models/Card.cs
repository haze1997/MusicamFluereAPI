public class Card
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Assignee { get; set; } = string.Empty;
    public string Priority { get; set; } = "Medium";  // Low, Medium, High, Urgent
    public string Status { get; set; } = "Backlog";    // Backlog, ToDo, Doing, Testing, Done
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
