using App.Domain.Barcodes;
using App.Domain.Barcodes.Dtos;

namespace App.Application.Barcodes.Validator;

public class UpdateBarcodeValidator : AbstractValidator<UpdateBarcodeDto>
{
    public UpdateBarcodeValidator()
    {

        RuleFor(x => x.FromCode).NotEmpty().NotNull().WithMessage(BarcodeErrorMessage.CodeRequired);

        RuleFor(x => x.FromCode).Matches(BarcodeConstraintProperty.BarcodeFormat).WithMessage(BarcodeErrorMessage.BarcodeFormat);

        RuleFor(x => x.ToCode).NotEmpty().NotNull().WithMessage(BarcodeErrorMessage.CodeRequired);

        RuleFor(x => x.ToCode).Matches(BarcodeConstraintProperty.BarcodeFormat).WithMessage(BarcodeErrorMessage.BarcodeFormat);


        //to code to int Greater Than from code to int
        RuleFor(x => x.ToCode).Must((x, toCode) =>
        {
            var fromCode = Convert.ToInt32(x.FromCode);
            var toCode2 = Convert.ToInt32(x.ToCode);
            return toCode2 > fromCode;
        }).WithMessage(BarcodeErrorMessage.ToCodeGreaterThanFromCode);

        //from code to int less than to code to int

        RuleFor(x => x.FromCode).Must((x, fromCode) =>
        {
            var fromCode2 = Convert.ToInt32(x.FromCode);
            var toCode = Convert.ToInt32(x.ToCode);
            return fromCode2 < toCode;
        }).WithMessage(BarcodeErrorMessage.FromCodeLessThanToCode);






    }
}
