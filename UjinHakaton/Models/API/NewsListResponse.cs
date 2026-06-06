using System;
using System.Collections.Generic;
using System.Text;
using UjinHakaton.Models.NewsModel;

namespace UjinHakaton.Models.API
{
    public class NewsListResponse
    {
        public string Command { get; set; }
        public string Message { get; set; }
        public int Error { get; set; }
        public List<NewsData> Items { get; set; }

        public Links Links { get; set; }

    }

    public class NewsData
    {
        public List<NewsItem> Items { get; set; }

    }
    public class Links
    {
        public string First { get; set; }
        public string Last { get; set; }
        public object? Prev { get; set; }
        public object? Next { get; set; }
    }
}
