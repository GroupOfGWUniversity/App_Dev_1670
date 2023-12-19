namespace App_Dev_1670.Models.ViewModels
{
    public class SaBVM
    {
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public SaBVM(List<Book> books, List<ApplicationUser> users)
        {
            this.Books = books;
            this.Users = users;
        }
    }
}
