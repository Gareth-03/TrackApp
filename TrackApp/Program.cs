class Program
{
    static void Main(string[] args)
    {
        Playlist playlist = new Playlist();

        playlist.AddTrack(new Track("Song 1", "Artist 1", "Album 1"));
        playlist.AddTrack(new Track("Song 2", "Artist 2", "Album 2"));
        playlist.AddTrack(new Track("Song 3", "Artist 3", "Album 3"));

        Console.WriteLine("Current Track: " + playlist.GetCurrentTrack());

        playlist.MoveNext();
        Console.WriteLine("Next Track: " + playlist.GetCurrentTrack());

        playlist.MovePrevious();
        Console.WriteLine("Previous Track: " + playlist.GetCurrentTrack());

        var foundTrack = playlist.FindTrack("Song 2");
        Console.WriteLine("Found Track: " + foundTrack);

        playlist.RemoveTrack("Song 2");
        Console.WriteLine("After Removal, Current Track: " + playlist.GetCurrentTrack());

        playlist.Shuffle();
        Console.WriteLine("After Shuffle, Current Track: " + playlist.GetCurrentTrack());
    }
}
