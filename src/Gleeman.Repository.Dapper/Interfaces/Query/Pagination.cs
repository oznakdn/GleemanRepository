namespace Gleeman.Repository.Dapper.Interfaces.Query;

public class Pagination
{
    public int MaxPageSize { get; set; }
    public int PageNumber { get; set; }

    private int _pageSize;
    public int PageSize
    {
        get { return _pageSize; }
        set
        {
            _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
    }
}
