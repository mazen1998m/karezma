using App.Domain.Barcodes;
using App.Domain.Barcodes.Dtos;
using Microsoft.Extensions.Configuration;

namespace App.Application.Barcodes;

internal class BarcodeService : Service<Barcode>, IBarcodeService
{
    private readonly IRepository<Barcode> _repository;
    private readonly IConfiguration conf;

    public BarcodeService(IRepository<Barcode> repository, IConfiguration conf) : base(repository)
    {
        _repository = repository;
        this.conf = conf;
    }

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
            lastBarcodeUsed = from - 1;
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

        var totalNumbers = toNumber - fromNumber + 1;

        if (lastUsedNumber == 0) return totalNumbers.ToString();

        var totalAvailableNumber = totalNumbers - (lastUsedNumber - fromNumber + 1);

        return totalAvailableNumber.ToString();

    }

    public async Task<bool> IsBarcodeMinimum()
    {
        var minimulOfBarcode = conf["MinimumOfBarcode"];
        var dto = await _repository.FirstOrDefaultAsync<UpdateBarcodeDto>();
        var AvailableCode = CalulateAvailableCode(dto);
        return AvailableCode.ToInt() <= minimulOfBarcode.ToInt();

    }
}

public interface IBarcodeService : IService<Barcode>, IAutoInjection
{
    Task<string> GetBarcode();
    string CalulateAvailableCode(UpdateBarcodeDto dto);

    Task<bool> IsBarcodeMinimum();
}

