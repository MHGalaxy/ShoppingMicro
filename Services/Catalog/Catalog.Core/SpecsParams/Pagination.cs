namespace Catalog.Core.SpecsParams;

public class Pagination<T>(int pageIndex, int pageSize, long count, IReadOnlyList<T> dataList)
    where T : class 
{
    public int PageIndex { get; set; } = pageIndex;
    public int PageSize { get; set; } = pageSize;
    public long Count { get; set; } = count;
    public IReadOnlyList<T> DataList { get; set; } = dataList;
}
