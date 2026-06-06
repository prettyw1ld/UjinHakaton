using System;
using System.Collections.Generic;
using System.Text;
using UjinHakaton.Models.Builds;

namespace UjinHakaton.Models.NewsModel
{
    public class NewsItem
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Published_at { get; set; }
        public DateTime? Expires_at { get; set; }
        public DateTime? Schedule_for { get; set; }
        public List<string> Images { get; set; }
        public Type Type { get; set; }
        public List<Buildings> Buildings { get; set; }
        public int Remote_id { get; set; }
        public bool Is_external { get; set; }
        public object? Targeting { get; set; }
    }
}
