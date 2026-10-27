namespace AshalLms.Core.Interfaces.Specification.SpecParams
{
    // Pagination model 
    public class BasicPaginationParam
    {
        private const int MaxPageSize = 50;
        private int pageSize = 10;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }

        public int PageIndex { get; set; } = 1;

    }
}
