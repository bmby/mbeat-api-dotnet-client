namespace Mbeat.Entities
{
    public class BmbyhoodUserPassword : Entity
    {
        public int BmbyUserId { get; set; }
        public string PasswordHash { get; set; }
    }
}
