namespace IgdbWrapper.Api.Dto
{
    public class IgdbImageDto : BaseDto
    {
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}