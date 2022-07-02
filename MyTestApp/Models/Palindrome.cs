using System.ComponentModel.DataAnnotations;

namespace MyTestApp.Models
{
    public class Palindrome
    {
        public string RevWord { get; set; } = string.Empty;
        public string Message { get; set; } = String.Empty;
        public bool IsPalindrome { get; set; }

        [Required(ErrorMessage = "You must enter a String, field can not be blank.")]
        public string InputWord { get; set; }
    }
}