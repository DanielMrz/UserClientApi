namespace UserClientApi.Entities
{
    public class UserClient
    {
        // Model
        //id?: number;
        //nickName = "";
        //firstName = "";
        //lastName = "";
        //email = "";
        //city = "";

        public int Id { get; set; }
        public string? NickName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }
    }
}
