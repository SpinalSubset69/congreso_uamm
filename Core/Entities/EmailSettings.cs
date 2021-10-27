namespace Core.Entities
{
    public class EmailSettings
    {
        public string EmailId{get; set;}
        public string Name {get ; set;}
        public string Password {get; set;}
        public string Host {get; set;}
        public int Port {get; set;}
        public bool UseSSl {get; set;}
    }
}