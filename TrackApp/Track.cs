public class Track
{
    public string Name { get; set; }
    public string Artist { get; set; }
    public string Album { get; set; }

    public Track(string name, string artist, string album)
    {
        Name = name;
        Artist = artist;
        Album = album;
    }

    public override string ToString()
    {
        return $"{Name} by {Artist} from the album {Album}";
    }
}
