namespace IgdbWrapper.Api.Dto
{
    public class GameDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Url { get; set; }
        public string Summary { get; set; }
        public long[] Developers { get; set; }
        public long Category { get; set; }
        public long[] Platforms { get; set; }
        public long Status { get; set; }
        public ReleaseDateDto[] ReleaseDates { get; set; }
        public IgdbImageDto Cover { get; set; }
    }
}