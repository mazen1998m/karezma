using App.Domain.Users;

namespace App.Domain.Documents
{
    public class Document : Entity
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public User? User { get; set; }
        public int? UserId { get; set; }

        internal class Configuration : ConfigureTable<Document>
        {
            protected override void ConfigureCustomizations()
            {
            }
        }
    }
}
