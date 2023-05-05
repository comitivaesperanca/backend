namespace ComitivaEsperanca.API.Domain.DTOs
{
    public class PaginatedItemsDTO<T>
    {
        public int PageIndex { get; }
        public int PageSize { get; }
        public int TotalItems { get; }
        public ICollection<T> ItemsOnPage { get; }

        public PaginatedItemsDTO(int pageIndex, int pageSize, int totalItems, ICollection<T> itemsOnPage)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalItems = totalItems;
            ItemsOnPage = itemsOnPage;
        }
    }
}
