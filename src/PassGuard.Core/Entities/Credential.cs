namespace PassGuard.Core.Entities;

public sealed class Credential
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public Uri Website { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Notes { get; set; }
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset? UpdatedAt { get; set; }

    private Credential() {
    }

    private Credential(Guid userId, Uri website, string username, string password, string notes)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Website = website;
        Username = username;
        Password = password;
        Notes = notes;
        CreatedAt = DateTimeOffset.UtcNow;
    }
    
    public static Credential Create(Guid userId, Uri website, string username, 
        string password, string notes) => new(userId, website, username, password, notes);
}