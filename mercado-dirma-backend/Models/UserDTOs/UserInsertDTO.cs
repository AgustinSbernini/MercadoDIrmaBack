namespace mercado_dirma_backend.Models.UserDTOs
{
    public class UserInsertDTO
    {
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Dni { get; set; }
        public DateTime BirthDate { get; set; }
        public long PhoneNumber { get; set; }
        public string Address { get; set; } = string.Empty;

    }
}
