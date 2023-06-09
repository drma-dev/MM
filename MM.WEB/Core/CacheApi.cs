﻿using Microsoft.Extensions.Caching.Memory;

namespace MM.WEB.Core
{
    public class CacheApi : ApiServices
    {
        public CacheApi(IHttpClientFactory http, IMemoryCache memoryCache) : base(http, memoryCache)
        {
        }

        private struct Endpoint
        {
            public static string News(string mode) => $"Public/Cache/News?mode={mode}";

            public static string Trailers(string mode) => $"Public/Cache/Trailers?mode={mode}";

            public static string GetRatings(string id, DateTime? date) => $"Public/Cache/Ratings?id={id}&release_date={date}";

            public static string GetReviews(string id, DateTime? date) => $"Public/Cache/Reviews?id={id}&release_date={date}";
        }

        //public async Task<FlixsterCache?> GetNews(string mode)
        //{
        //    return await GetAsync<FlixsterCache>(Endpoint.News(mode), false);
        //}

        //public async Task<YoutubeCache?> GetTrailers(string mode)
        //{
        //    return await GetAsync<YoutubeCache>(Endpoint.Trailers(mode), false);
        //}

        //public async Task<RatingsCache?> GetRatings(string id, DateTime? releaseDate)
        //{
        //    return await GetAsync<RatingsCache>(Endpoint.GetRatings(id, releaseDate), false);
        //}

        //public async Task<MetaCriticCache?> GetReviews(string id, DateTime? releaseDate)
        //{
        //    return await GetAsync<MetaCriticCache>(Endpoint.GetReviews(id, releaseDate), false);
        //}
    }
}