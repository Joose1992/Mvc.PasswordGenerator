namespace Mvc.PasswordGenerator.Models
{
    public class PasswordGeneratorViewModel
    {
        public int PasswordLength { get; set; }
        public bool SpecialCharacters { get; set; }
        public string PasswordResult { get; set; } = "";
    }
}
