using Newtonsoft.Json;

namespace RazorVideo;

[JsonObject(MemberSerialization.OptIn)]
public class VideoDimension
{
    public VideoDimension()
    {
    }

    public VideoDimension(int height, int width)
    {
        Height = height;
        Width = width;
    }

    [JsonProperty]
    public int Height { get; set; }
    [JsonProperty]
    public int Width { get; set; }
}