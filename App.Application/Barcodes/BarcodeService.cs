using App.Domain.Barcodes;

namespace App.Application.Barcodes;

internal class BarcodeService : IBarcodeService
{
    private readonly IRepository<Barcode> _repository;

    public BarcodeService(IRepository<Barcode> repository)
    {
        _repository = repository;
    }

    //increase the barcode count
    public async Task<string> GetBarcode()
    {
        var barcode = await _repository.FirstOrDefaultAsync();
        var lastBarcodeUsed = decimal.Parse(barcode.LastCodeUsed);
        var from = decimal.Parse(barcode.FromCode);
        var to = decimal.Parse(barcode.ToCode);

        if (lastBarcodeUsed > to)
        {
            return "-1";
        }

        else if (lastBarcodeUsed == 0)
        {
            lastBarcodeUsed = from;
        }

        else if (lastBarcodeUsed < from)
        {
            return "-1";
        }

        var newBarcode = lastBarcodeUsed++;
        barcode.LastCodeUsed = newBarcode.ToString();
        await _repository.SaveUpdateAsync(barcode);
        return newBarcode.ToString();
    }
}

public interface IBarcodeService : IAutoInjection
{
    Task<string> GetBarcode();
}

