using Microsoft.EntityFrameworkCore;
using TheHandymanOfCapeCod.Core.Models.Project;

namespace TheHandymanOfCapeCod.Core.Tools
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int CurrentIndex { get; set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize, int currentIndex)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            CurrentIndex = currentIndex;
            this.AddRange(items);
        }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;


        public static PaginatedList<T> CreateAsync(List<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var currentIndex = ((pageIndex - 1) * pageSize);
            return new PaginatedList<T>(items, count, pageIndex, pageSize, currentIndex);
        }
    }
}
