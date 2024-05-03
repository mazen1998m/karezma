using App.Data.GenericRepository;
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
            .ForMember(e => e.LastCodeUsed, o => o.MapFrom(d => GetLastCodeUsed(d.Id)))
            .ForMember(e => e.NumberOfCodeAvailable, o => o.MapFrom(d => CalulateAvailableCode(d)))
            ;
    }

    private string CalulateAvailableCode(UpdateBarcodeDto dto)
    {
        int from = int.Parse(dto.FromCode);
        int to = int.Parse(dto.ToCode);


        int last = int.Parse(GetLastCodeUsed(dto.Id));
        int totalAvailable = to - from + 1;
        return (totalAvailable - last).ToString();
    }


    private string GetLastCodeUsed(int id)
    {
        var repository = _repository.Inject();
        var lastCode = repository.FirstOrDefaultAsync(x => x.Id == id, s => new { s.Id, s.LastCodeUsed });
        lastCode.Wait();
        return lastCode.Result.LastCodeUsed;
    }



}
