namespace La8b.Models
{
    public class NewLera
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public NewLera(
            string first,
            string last,
            string email,
            string password)
        {
            FirstName = first;
            LastName = last;
            Email = email;
            Password = password;
        }

        public NewLera(
            string email,
            string password)
        {
            Email = email;
            Password = password;
        }

        public NewLera() { }
    }
}
