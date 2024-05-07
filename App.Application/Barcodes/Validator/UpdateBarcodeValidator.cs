using App.Domain.Barcodes;
using App.Domain.Barcodes.Dtos;

namespace App.Application.Barcodes.Validator;

public class UpdateBarcodeValidator : AbstractValidator<UpdateBarcodeDto>
{
    public IRepository<Barcode> _repository { get; set; }
    public UpdateBarcodeValidator()
    {

        RuleFor(x => x.FromCode).NotEmpty().NotNull().WithMessage(BarcodeErrorMessage.CodeRequired);

        RuleFor(x => x.FromCode).Matches(BarcodeConstraintProperty.BarcodeFormat).WithMessage(BarcodeErrorMessage.BarcodeFormat);

        RuleFor(x => x.ToCode).NotEmpty().NotNull().WithMessage(BarcodeErrorMessage.CodeRequired);

        RuleFor(x => x.ToCode).Matches(BarcodeConstraintProperty.BarcodeFormat).WithMessage(BarcodeErrorMessage.BarcodeFormat);


        //to code to int Greater Than from code to int
        RuleFor(x => x.ToCode).Must((x, toCode) =>
        {
            var fromCode = decimal.Parse(x.FromCode);
            var toCode2 = decimal.Parse(x.ToCode);
            return toCode2 > fromCode;
        }).WithMessage(BarcodeErrorMessage.ToCodeGreaterThanFromCode);

        //from code to int less than to code to int

        RuleFor(x => x.FromCode).Must((x, fromCode) =>
        {
            var fromCode2 = decimal.Parse(x.FromCode);
            var toCode = decimal.Parse(x.ToCode);
            return fromCode2 < toCode;
        }).WithMessage(BarcodeErrorMessage.FromCodeLessThanToCode);

        RuleFor(x => x.ToCode).Must(ToCodeIsUsed).WithMessage(BarcodeErrorMessage.ToCodeIsUsed);


    }

    private bool ToCodeIsUsed(string toCode)
    {
        var repository = _repository.Inject();
        var barcode = repository.FirstOrDefault();
        var lastBarcodeUsed = decimal.Parse(barcode.LastCodeUsed);

        return decimal.Parse(toCode) > lastBarcodeUsed;
    }
}
