using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Introduction to C#", "Joseph Kanu", 300);
        video1.AddComment(new Comment("Alice", "Great video! Very inspiring."));
        video1.AddComment(new Comment("Bob", "I learned a lot from this video. Thanks!"));
        video1.AddComment(new Comment("David", "This is really helpful."));

        Video video2 = new Video("How to Cook the Perfect Steak", "Chef Mike", 600);
        video2.AddComment(new Comment("Charlie", "This recipe is amazing!"));
        video2.AddComment(new Comment("Dana", "I tried this and it turned out perfect!"));
        video2.AddComment(new Comment("Eve", "I will definitely try this!"));

        Video video3 = new Video("The History of the Internet", "Tech Guru", 900);
        video3.AddComment(new Comment("Eve", "Fascinating history!"));
        video3.AddComment(new Comment("Frank", "I didn't know about some of these facts."));
        video3.AddComment(new Comment("Grace", "Very interesting information!"));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"Commenter: {comment.GetCommenterName()}");
                Console.WriteLine($"Comment: {comment.GetCommentText()}");
            }

            Console.WriteLine();
        }
    }
}