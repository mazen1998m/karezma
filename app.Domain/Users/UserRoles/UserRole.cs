using App.Domain.Users.Roles;

namespace App.Domain.Users.UserRoles;

public class UserRole : Entity
{
    public User User { get; set; }
    public int UserId { get; set; }
    public Role Role { get; set; }
    public int RoleId { get; set; }
    internal class Configuration : ConfigureTable<UserRole>
    {
        protected override void ConfigureCustomizations()
        {

            Builder.HasKey(ur => new { ur.UserId, ur.RoleId });
            Builder.HasOne(ur => ur.User)
                   .WithMany()
                   .HasForeignKey(ur => ur.UserId);
            Builder.HasOne(ur => ur.Role)
                   .WithMany()
                   .HasForeignKey(ur => ur.RoleId);
        }
    }
}
