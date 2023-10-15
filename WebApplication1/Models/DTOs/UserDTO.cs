namespace WebApplication1.Models.DTOs
{
    public class UserDTO
    {
        public string name {  get; set; }
        public string email { get; set; }
        public UserDTO() { }
        public UserDTO(string name, string email) { }
    }
}
