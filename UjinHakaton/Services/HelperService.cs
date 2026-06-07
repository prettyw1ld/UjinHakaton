using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using UjinTemplateServer.Common;
using UjinTemplateServer.Models;

namespace UjinHakaton.Services
{
    public class HelperService(HttpClient httpClient, AppDbContext dbContext)
    {
        private readonly HttpClient _httpClient = httpClient;
        

    }
}
