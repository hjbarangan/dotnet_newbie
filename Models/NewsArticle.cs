
public class NewsArticle
{
    public Source? Source { get; set; }
    public string? Author { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    public string? UrlToImage { get; set; }
    public DateTime PublishedAt { get; set; }
    public string? Content { get; set; }
}


public class Source
{
    public string? Id { get; set; }
    public string ?Name { get; set; }
}

public class NewsResponse
{
    public string? Status { get; set; }
    public int TotalResults { get; set; }
    public List<NewsArticle>? Articles { get; set; }
}