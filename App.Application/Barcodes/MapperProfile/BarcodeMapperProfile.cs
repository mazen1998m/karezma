using App.Domain.Barcodes;
using App.Domain.Barcodes.Dtos;

namespace App.Application.Barcodes.MapperProfile;

public class BarcodeMapperProfile : Profile
{

    private readonly IRepository<Barcode> _repository;
    public BarcodeMapperProfile()
    {
        CreateMap<Barcode, UpdateBarcodeDto>()
            .ReverseMap()
            .ForMember(e => e.LastCodeUsed, o => o.MapFrom(d => GetLastCodeUsed(d.Id, d.FromCode)))
            //.ForMember(e => e.ToCode, o => o.MapFrom(d => GetLastCodeUsed(d.Id, d.FromCode)))
            //.ForMember(e => e.NumberOfCodeAvailable, o => o.MapFrom(d => CalulateAvailableCode(d)))
            ;
    }


    private string CalulateAvailableCode(UpdateBarcodeDto dto)
    {
        var lastUsedNumber = decimal.Parse(dto.LastCodeUsed);
        var fromNumber = decimal.Parse(dto.FromCode);
        var toNumber = decimal.Parse(dto.ToCode);

        // Total numbers in the range
        var totalNumbers = toNumber - fromNumber + 1;

        // Numbers used
        var numbersUsed = (lastUsedNumber < fromNumber) ? 0 : (lastUsedNumber - fromNumber + 1);

        // Total available numbers
        var totalAvailableNumber = totalNumbers - numbersUsed;

        return totalAvailableNumber.ToString();

    }


    private string GetLastCodeUsed(int id, string from)
    {
        var repository = _repository.Inject();
        var lastCode = repository.FirstOrDefaultAsync(x => x.Id == id, s => new { s.Id, s.LastCodeUsed });
        lastCode.Wait();
        var lastCodeUsed = decimal.Parse(lastCode.Result.LastCodeUsed);
        var fromCode = decimal.Parse(from);
        if (fromCode > lastCodeUsed)
        {
            return 0.ToString();
        }
        return lastCodeUsed.ToString();
    }
    //private string GetToCode(int id, string from, string to)
    //{
    //    var repository = _repository.Inject();
    //    var barcode = repository.FirstOrDefaultAsync(x => x.Id == id, s => new { s.Id, s.ToCode, s.LastCodeUsed, s.FromCode });
    //    barcode.Wait();
    //    var oldToCode = decimal.Parse(barcode.Result.ToCode);
    //    var oldFromCode = decimal.Parse(barcode.Result.FromCode);
    //    var lastCodeUsed = decimal.Parse(barcode.Result.LastCodeUsed);

    //    var fromCode = decimal.Parse(from);
    //    var toCode = decimal.Parse(to);

    //    if (lastCodeUsed == oldToCode && lastCodeUsed > fromCode && oldToCode<=toCode)
    //    {
    //        oldToCode = oldFromCode;
    //    }
    //    return oldToCode.ToString();
    //}


}
