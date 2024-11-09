namespace Hotel_Management_System.Cores.Dtos
{
    public class AuthModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }
        public bool IsAuthantication { get; set; }
        public DateTime ExpireOn { get; set; }
    }
}
