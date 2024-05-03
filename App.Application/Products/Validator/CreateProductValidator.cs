using App.Domain.Products;
using App.Domain.Products.Dtos;

namespace App.Application.Products.Validator;

public class CreateProductValidator : AbstractValidator<CreateProductDto>
{

    public IService<Product> _productService { get; set; }


    public CreateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ProductErrorMessage.NameRequired)

            .MaximumLength(ProductConstraintProperty.NameMaximumLength).WithMessage(ProductErrorMessage.NameMaximumLength)

            .MinimumLength(ProductConstraintProperty.NameMinimumLength).WithMessage(ProductErrorMessage.NameMinimumLength)

            .Must(IsNameUnique).WithMessage(ProductErrorMessage.NameUnique)

            ;

        RuleFor(x => x.Model)
            .NotEmpty().WithMessage(ProductErrorMessage.ModelRequired)

            .MaximumLength(ProductConstraintProperty.ModelMaximumLength).WithMessage(ProductErrorMessage.ModelMaximumLength)

            .MinimumLength(ProductConstraintProperty.ModelMinimumLength).WithMessage(ProductErrorMessage.ModelMinimumLength)

            .Must(IsModelUnique).WithMessage(ProductErrorMessage.ModelUnique)
            ;

        //RuleFor(x => x.Barcode)
        //    .MaximumLength(ProductConstraintProperty.BarcodeMaximumLength).WithMessage(ProductErrorMessage.BarcodeMaximumLength)

        //    .MinimumLength(ProductConstraintProperty.BarcodeMinimumLength).WithMessage(ProductErrorMessage.BarcodeMinimumLength)

        //    .Must(IsBarcodeUnique).WithMessage(ProductErrorMessage.BarcodeUnique)

        //    .Matches(ProductConstraintProperty.BarcodeFormat).WithMessage(ProductErrorMessage.BarcodeFormat)
        //    ;

        RuleFor(x => x.Description)
            .MaximumLength(ProductConstraintProperty.DescriptionMaximumLength).WithMessage(ProductErrorMessage.DescriptionMaximumLength)
            ;

    }

    private bool IsModelUnique(string model)
    {
        _productService = _productService.Inject();
        return _productService.Any(x => x.Model == model) == 0;
    }

    //IsNameUnique
    private bool IsNameUnique(string name)
    {
        _productService = _productService.Inject();
        return _productService.Any(x => x.Name == name) == 0;
    }

    //IsBarcodUnique
    private bool IsBarcodeUnique(string barcode)
    {
        _productService = _productService.Inject();
        return _productService.Any(x => x.Barcode == barcode && x.Barcode != "0" && !x.Barcode.IsNotNullOrEmpty()) == 0;
    }


}
