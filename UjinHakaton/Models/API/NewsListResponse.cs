using System;
using System.Collections.Generic;
using System.Text;
using UjinHakaton.Models.NewsModel;

namespace UjinHakaton.Models.API
{
    public class NewsListResponse
    {
        public string? Command { get; set; }
        public string? Message { get; set; }
        public int Error { get; set; }
        public NewsListData? Data { get; set; }
    }

    public class NewsListData
    {
        public List<NewsItem> Items { get; set; } = [];
    }
}
