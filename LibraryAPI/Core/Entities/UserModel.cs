namespace LibraryManagementSystemBackend.Core.Entities
{
    public abstract class UserModel
    {
        public int UserID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int RoleID { get; set; }
    }

}
