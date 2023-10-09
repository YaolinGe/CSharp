using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatch
{
    internal class StackOverflowPost
    {
        private readonly string _title;
        private readonly string _description;
        private readonly DateTime _created;
        private int _votes;

        public StackOverflowPost(string title, string description)
        {
            _title = title;
            _description = description;
            _created = DateTime.Now;
            _votes = 0;
        }

        public void UpVote()
        {
            _votes++;
        }

        public void DownVote()
        {
            _votes--;
        }

        public int GetVotes()
        {
            return _votes;
        }

        public void DisplayPost()
        {
            Console.WriteLine("Title: {0}", _title);
            Console.WriteLine("Description: {0}", _description);
            Console.WriteLine("Created: {0}", _created);
            Console.WriteLine("Votes: {0}", _votes);
        }
    }
}
