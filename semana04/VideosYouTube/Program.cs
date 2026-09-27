using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video(
            "Learning C# Basics",
            "Code Academy",
            600
        );

        video1._comments.Add(new Comment(
            "Anna",
            "This video helped me a lot!"
        ));

        video1._comments.Add(new Comment(
            "Lucas",
            "Great explanation."
        ));

        video1._comments.Add(new Comment(
            "Maria",
            "I am learning C# too!"
        ));

        videos.Add(video1);


        Video video2 = new Video(
            "How to Make Chocolate Cake",
            "Cooking Time",
            480
        );

        video2._comments.Add(new Comment(
            "John",
            "The cake looks delicious!"
        ));

        video2._comments.Add(new Comment(
            "Sarah",
            "I will try this recipe."
        ));

        video2._comments.Add(new Comment(
            "Emily",
            "Very easy to follow."
        ));

        videos.Add(video2);


        Video video3 = new Video(
            "Best Places to Travel",
            "Travel World",
            720
        );

        video3._comments.Add(new Comment(
            "David",
            "I want to visit these places."
        ));

        video3._comments.Add(new Comment(
            "Sophia",
            "Beautiful locations!"
        ));

        video3._comments.Add(new Comment(
            "Michael",
            "Thanks for the recommendations."
        ));

        videos.Add(video3);


        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");

            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"- {comment._name}: {comment._text}");
            }

            Console.WriteLine();
        }
    }
}