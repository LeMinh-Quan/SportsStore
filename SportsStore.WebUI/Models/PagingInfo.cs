using System;

namespace SportsStore.WebUI.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages => ItemsPerPage > 0
            ? (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage)
            : 0;
    }
}