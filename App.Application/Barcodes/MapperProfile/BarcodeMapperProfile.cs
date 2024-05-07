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
            .ForMember(e => e.NumberOfCodeAvailable, o => o.MapFrom(d => CalulateAvailableCode(d)))
            ;
    }

    private string CalulateAvailableCode(UpdateBarcodeDto dto)
    {
        var from = decimal.Parse(dto.FromCode);
        var to = decimal.Parse(dto.ToCode);


        var last = decimal.Parse(GetLastCodeUsed(dto.Id, dto.FromCode));
        var totalAvailable = to - from + 1;
        return (totalAvailable - last).ToString();
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



}
