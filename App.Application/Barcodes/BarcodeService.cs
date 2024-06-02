using App.Domain.Barcodes;
using App.Domain.Barcodes.Dtos;

namespace App.Application.Barcodes;

internal class BarcodeService : Service<Barcode>, IBarcodeService
{
    private readonly IRepository<Barcode> _repository;

    public BarcodeService(IRepository<Barcode> repository) : base(repository)
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

        if (lastBarcodeUsed >= to)
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

        var newBarcode = lastBarcodeUsed + 1;
        barcode.LastCodeUsed = newBarcode.ToString();
        await _repository.SaveUpdateAsync(barcode);
        return newBarcode.ToString();
    }

    public string CalulateAvailableCode(UpdateBarcodeDto dto)
    {
        var lastUsedNumber = decimal.Parse(dto.LastCodeUsed);
        var fromNumber = decimal.Parse(dto.FromCode);
        var toNumber = decimal.Parse(dto.ToCode);

        // Total numbers in the range
        var totalNumbers = toNumber - fromNumber + 1;

        // Numbers used
        //var numbersUsed = (lastUsedNumber < fromNumber) ? 0 : (lastUsedNumber - fromNumber + 1);

        // Total available numbers
        var totalAvailableNumber = totalNumbers - lastUsedNumber;

        return totalAvailableNumber.ToString();

    }


}

public interface IBarcodeService : IService<Barcode>, IAutoInjection
{
    Task<string> GetBarcode();
    string CalulateAvailableCode(UpdateBarcodeDto dto);
}

