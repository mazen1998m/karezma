namespace App.Domain.Notification;

public class SystemNotification : Entity
{
    public string Title { get; set; }
    public string Body { get; set; }
    public string Link { get; set; }

    internal class Configuration : ConfigureTable<SystemNotification>
    {
        protected override void ConfigureCustomizations()
        {
            Builder.Property(x => x.Title).IsRequired(false);
            Builder.Property(x => x.Body).IsRequired(false);
            Builder.Property(x => x.Link).IsRequired(false);
        }
    }
}
