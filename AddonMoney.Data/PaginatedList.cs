namespace AddonMoney.Data
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; set; } = new();

        public int TotalPages { get; set; }

        public PaginatedList(List<T> items, int totalItems, int pageSize)
        {
            Items = items;
            TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);
        }
    }
}
