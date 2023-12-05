namespace mercado_dirma_backend.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Dni { get; set; }
        public DateTime BirthDate { get; set; }
        public long PhoneNumber { get; set; }
        public string Address { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime DeletionDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }

        public User()
        {

        }
        public User(int idUser)
        {
            IdUser = idUser;
        }
    }
}
