namespace lab2
{
    public class Author
    {
        public Author(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public event App.ReceiveAuthorWork PublishEvent;

        public void Publish(AuthorWork authorWork)
        {
            PublishEvent?.Invoke(this, authorWork);
        }
    }
}