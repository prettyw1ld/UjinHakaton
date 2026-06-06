using System.Collections.Generic;
using System.Text.RegularExpressions;
using UjinHakaton.Models.Builds;

namespace UjinHakaton.Models.NewsModel
{
    public class NewsItem
    {
        public int Id { get; set; }
        public int? Status { get; set; }

        public string? Title { get; set; }

        public string? Text
        {
            get;
            set 
            {
                field = Regex.Replace(value, @"<[^>]+>", "");
            }
        }

        public string? Date { get; set; }
        public string? Created_at { get; set; }
        public string? Published_at { get; set; }
        public string? Expires_at { get; set; }
        public string? Schedule_for { get; set; }

        public List<string> Images { get; set; } = [];
        public Type? Type { get; set; }
        public List<Buildings> Buildings { get; set; } = [];

        public string? Remote_id { get; set; }
        public bool? Is_external { get; set; }
        public object? Targeting { get; set; }
    }
}
