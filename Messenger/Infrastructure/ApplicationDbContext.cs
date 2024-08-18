using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserPhoto> UserPhotos { get; set; }
    public DbSet<ChatAccessibility> ChatAccessibilities { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<ChatType> ChatTypes { get; set; }
    public DbSet<ChatMember> ChatMembers { get; set; }
    public DbSet<MessageType> MessageTypes { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<MemberRole> MemberRoles { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options) {}

    public ApplicationDbContext() {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        
        //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MessengerDb;Username=postgres;Password=qwerty");
        optionsBuilder.LogTo(Console.WriteLine);
    }
}