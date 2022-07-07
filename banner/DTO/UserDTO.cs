namespace banner.DTO
{

    public class UserDTO:DTO
    {
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
    }
    public class LoginDTO
    {
        public string Username { get; set; }//this field will be used to search user from Username or Email or Phone
        public string Password { get; set; }
    }
}
