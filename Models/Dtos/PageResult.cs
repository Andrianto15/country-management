namespace CountryManagement.Models.Dtos
{
    public class PagedResult<T>
    {
        public T Data { get; set; } = default!;
        public int TotalRecords { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

}
