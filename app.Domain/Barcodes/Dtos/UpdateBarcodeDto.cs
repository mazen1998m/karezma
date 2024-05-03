namespace App.Domain.Barcodes.Dtos;

public class UpdateBarcodeDto : Dto
{
    public string FromCode { get; set; }
    public string ToCode { get; set; }
    public string LastCodeUsed { get; set; }

    public string NumberOfCodeAvailable { get; set; }
}
