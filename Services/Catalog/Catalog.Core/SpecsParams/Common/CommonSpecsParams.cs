namespace Catalog.Core.SpecsParams.Common;

public class CommonSpecsParams
{
    private int _maxPageSize { get; set; } = 100;
    public int PageSize
    {
        get => field;
        set => field = value > _maxPageSize ? _maxPageSize : value;
    }

    public int PageIndex { get; set; } = 0;
    public string SortField { get; set; }
    public SortType SortType { get; set; } = SortType.Asc;
    public string Search { get; set; } 
}


public enum SortType
{
    Asc = 0,
    Desc = 1,
}