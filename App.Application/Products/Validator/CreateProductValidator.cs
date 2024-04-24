using App.Domain.Products;
using App.Domain.Products.Dtos;
using Muslim.Filter.Extensions;

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

            .MustAsync(IsNameUnique).WithMessage(ProductErrorMessage.NameUnique)

            ;

        RuleFor(x => x.Model)
            .NotEmpty().WithMessage(ProductErrorMessage.ModelRequired)

            .MaximumLength(ProductConstraintProperty.ModelMaximumLength).WithMessage(ProductErrorMessage.ModelMaximumLength)

            .MinimumLength(ProductConstraintProperty.ModelMinimumLength).WithMessage(ProductErrorMessage.ModelMinimumLength)

            .MustAsync(IsModelUnique).WithMessage(ProductErrorMessage.ModelUnique)
            ;

        RuleFor(x => x.Barcode)
            .MaximumLength(ProductConstraintProperty.BarcodeMaximumLength).WithMessage(ProductErrorMessage.BarcodeMaximumLength)

            .MinimumLength(ProductConstraintProperty.BarcodeMinimumLength).WithMessage(ProductErrorMessage.BarcodeMinimumLength)

            .MustAsync(IsBarcodUnique).WithMessage(ProductErrorMessage.BarcodeUnique)

            .Matches(ProductConstraintProperty.BarcodeFormat).WithMessage(ProductErrorMessage.BarcodeFormat)
            ;

        RuleFor(x => x.Description)
            .MaximumLength(ProductConstraintProperty.DescriptionMaximumLength).WithMessage(ProductErrorMessage.DescriptionMaximumLength)
            ;

    }

    private async Task<bool> IsModelUnique(string model, CancellationToken token)
    {
        _productService = _productService.Inject();
        return await _productService.AnyAsync(x => x.Model == model) == 0;
    }

    //IsNameUnique
    private async Task<bool> IsNameUnique(string name, CancellationToken token)
    {
        _productService = _productService.Inject();
        return await _productService.AnyAsync(x => x.Name == name) == 0;
    }

    //IsBarcodUnique
    private async Task<bool> IsBarcodUnique(string barcode, CancellationToken token)
    {
        _productService = _productService.Inject();
        return await _productService.AnyAsync(x => x.Barcode == barcode && x.Barcode != "0" && !x.Barcode.IsNotNullOrEmpty()) == 0;
    }


}
