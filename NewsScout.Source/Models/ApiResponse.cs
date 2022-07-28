namespace NewsScout.Models
{
    public class ApiResponse
    {
        public string? Status { get; set; }
        public int? TotalResults { get; set; }
        public Result[]? Results { get; set; }
        public int? NextPage { get; set; }
    }

    public class Result
    {
        public string? Title { get; set; }
        public string? Link { get; set; }
        public string[]? Keywords { get; set; }
        public string[]? Creator { get; set; }
        public string? VideoUrl { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public string? PubDate { get; set; }
        public string? ImageUrl { get; set; }
        public string? SourceId { get; set; }
        public string[]? Country { get; set; }
        public string[]? Category { get; set; }
        public string? Language { get; set; }
    }
}
