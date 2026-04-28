namespace Catalog.Core.SpecsParams.Common;

public class CommonSpecsParams
{
    //private int _pageSize { get; set; } = 10;
    //private int _maxPageSize { get; set; } = 100;
    //public int PageSize 
    //{ 
    //    get => _pageSize; 
    //    set => _pageSize = value > _maxPageSize ? _maxPageSize : value; 
    //}

    private int _pageSize { get; set; } = 10;
    private int _maxPageSize { get; set; } = 100;
    public int PageSize
    {
        get => field;
        set => field = value > _maxPageSize ? _maxPageSize : value;
    }

    public int PageIndex { get; set; } = 0;
    public string Sort { get; set; }
    public string Search { get; set; } 
}
