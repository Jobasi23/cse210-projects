using System;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        var videos = new List<Video>();

        var video1 = new Video("How to Cook Pasta", "Chef John", 420);
        video1.AddComment(new Comment("Alice", "Great recipe!"));
        video1.AddComment(new Comment("Bob", "Tried it and loved it."));
        video1.AddComment(new Comment("Charlie", "Can you make a gluten-free version?"));
        videos.Add(video1);

        var video2 = new Video("Top 10 Coding Tips", "CodeMaster", 600);
        video2.AddComment(new Comment("Dave", "Very helpful, thanks!"));
        video2.AddComment(new Comment("Eve", "Tip #7 changed my life."));
        video2.AddComment(new Comment("Frank", "Can you do a Python version?"));
        videos.Add(video2);

        var video3 = new Video("Travel Vlog: Japan", "Wanderlust", 900);
        video3.AddComment(new Comment("Grace", "Beautiful scenery!"));
        video3.AddComment(new Comment("Heidi", "I want to visit Japan now."));
        video3.AddComment(new Comment("Ivan", "What camera did you use?"));
        videos.Add(video3);

        var video4 = new Video("Guitar Tutorial", "MusicMan", 480);
        video4.AddComment(new Comment("Judy", "Easy to follow!"));
        video4.AddComment(new Comment("Ken", "Can you do a song tutorial next?"));
        video4.AddComment(new Comment("Leo", "Thanks for the tips."));
        videos.Add(video4);

        // Display video info and comments
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"  {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }

    public class Video
    {
        public string Title { get; }
        public string Author { get; }
        public int Length { get; }
        public List<Comment> Comments { get; }

        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
            Comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public int GetNumberOfComments()
        {
            return Comments.Count;
        }
    }

    public class Comment
    {
        public string Name { get; }
        public string Text { get; }

        public Comment(string name, string text)
        {
            Name = name;
            Text = text;
        }
    }
}