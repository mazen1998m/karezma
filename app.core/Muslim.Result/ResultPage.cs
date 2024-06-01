namespace App.core.Muslim.Result;

public class ResultPage
{

    public int? Count { get; private init; }
    public int? NumberOfPages { get; private set; }

    public int? PageSize { get; private init; }

    public static ResultPage Create(int count, int pageSize)
    {
        if (count == 0 || pageSize == 0) return new ResultPage
        {
            Count = 0,
            PageSize = 0,
            NumberOfPages = 0,
        };
        var result = new ResultPage
        {
            Count = count,
            PageSize = pageSize
        };

        result.SetNumberOfPages();

        return result;
    }


    private void SetNumberOfPages()
    {
        NumberOfPages = Count / PageSize;
        if (Count % PageSize != 0) NumberOfPages += 1;
    }


}