using System.ComponentModel.DataAnnotations;

namespace DotNet_API_E_Book_Application.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public String Title { get; set; }
        public String Author { get; set; }
        public String Description { get; set; }
    }
}
