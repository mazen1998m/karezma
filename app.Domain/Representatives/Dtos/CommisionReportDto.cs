using App.Domain.Orders.Dtos;


namespace App.Domain.Representatives.Dtos;

public class CommisionReportDto : Dto
{
    public double Commision { get; set; }

    public List<ListOrderDto> Orders { get; set; }
}
