using IgdbWrapper.Api.Enums;

namespace IgdbWrapper.Api.Dto
{
    public class ReleaseDateDto : BaseDto
    {
        public string Human { get; set; }
        public Region Region { get; set; }
        public int M { get; set; }
        public int Y { get; set; }
        public long Date { get; set; }
    }
}