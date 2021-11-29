namespace lab2
{
    public class AuthorWork
    {
        public AuthorWork(string genre, string title, int pagesCount)
        {
            Genre = genre;
            Title = title;
            PagesCount = pagesCount;
        }

        public string Genre { get; }
        public string Title { get; }
        public int PagesCount { get; }

        public bool ValidateData()
        {
            return !(string.IsNullOrEmpty(Genre) ||
                     string.IsNullOrEmpty(Title) ||
                     PagesCount == 0);
        }

        public override string ToString()
        {
            return $"{Genre}, {Title}, {PagesCount} с.";
        }
    }
}