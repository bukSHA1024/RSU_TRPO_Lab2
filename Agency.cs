using System;
using System.Collections.Generic;

namespace lab2
{
    public class Agency
    {
        public Agency(string name)
        {
            Name = name;
            Received = new List<AuthorWork>();
            SubscribedAuthors = new List<Author>();
        }

        public string Name { get; }

        public List<AuthorWork> Received { get; }

        private List<Author> SubscribedAuthors { get; }

        public void ReceiveAuthorWork(object sender, AuthorWork authorWork)
        {
            Received.Add(authorWork);
        }

        public void Subscribe(Author author)
        {
            if (author == null) throw new ArgumentNullException(nameof(author));
            if (!SubscribedAuthors.Contains(author))
            {
                SubscribedAuthors.Add(author);
                author.PublishEvent += ReceiveAuthorWork;
            }
        }

        public void Unsubscribe(Author author)
        {
            if (author == null) throw new ArgumentNullException(nameof(author));
            SubscribedAuthors.Remove(author);
            author.PublishEvent -= ReceiveAuthorWork;
        }
    }
}