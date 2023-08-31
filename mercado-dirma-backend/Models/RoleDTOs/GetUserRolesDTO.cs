namespace mercado_dirma_backend.Models.RoleDTOs
{
    public class GetUserRolesDTO
    {
        public int IdUser_Role { get; set; }
        public int IdUser { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int IdRole { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }
}
