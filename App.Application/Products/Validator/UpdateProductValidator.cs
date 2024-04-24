using App.Domain.Products;
using App.Domain.Products.Dtos;


namespace App.Application.Products.Validator;

public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
{
    public IService<Product> _productService { get; set; }
    public int ProductId { get; set; }

    public UpdateProductValidator()
    {

        RuleFor(x => x.Id).Must(SetProductId);

        #region Name

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ProductErrorMessage.NameRequired)

            .MustAsync(IsNameUnique).WithMessage(ProductErrorMessage.NameUnique)

            .MaximumLength(ProductConstraintProperty.NameMaximumLength).WithMessage(ProductErrorMessage.NameMaximumLength)

            .MinimumLength(ProductConstraintProperty.NameMinimumLength).WithMessage(ProductErrorMessage.NameMinimumLength);

        #endregion

        #region Model

        RuleFor(x => x.Model)
            .NotEmpty().WithMessage(ProductErrorMessage.ModelRequired)

            .MustAsync(IsModelUnique).WithMessage(ProductErrorMessage.ModelUnique)

            .MaximumLength(ProductConstraintProperty.ModelMaximumLength).WithMessage(ProductErrorMessage.ModelMaximumLength)

            .MinimumLength(ProductConstraintProperty.ModelMinimumLength).WithMessage(ProductErrorMessage.ModelMinimumLength);

        #endregion


        #region Barcode

        RuleFor(x => x.Barcode)
            .MustAsync(IsBarcodUnique).WithMessage(ProductErrorMessage.BarcodeUnique)

            .MaximumLength(ProductConstraintProperty.BarcodeMaximumLength).WithMessage(ProductErrorMessage.BarcodeMaximumLength)

            .MinimumLength(ProductConstraintProperty.BarcodeMinimumLength).WithMessage(ProductErrorMessage.BarcodeMinimumLength)

            .Matches(ProductConstraintProperty.BarcodeFormat).WithMessage(ProductErrorMessage.BarcodeFormat)
            ;

        #endregion

        #region Description

        RuleFor(x => x.Description)
            .MaximumLength(ProductConstraintProperty.DescriptionMaximumLength).WithMessage(ProductErrorMessage.DescriptionMaximumLength);

        #endregion


    }

    private async Task<bool> IsModelUnique(string model, CancellationToken token)
    {
        _productService = _productService.Inject();
        var oldProductModel = _productService.FirstOrDefault(user => user.Id == ProductId, u => new { u.Id, u.Model }).Response.Model;
        return await _productService.AnyAsync(x => x.Model == model && x.Model != oldProductModel) == 0;
    }

    //IsNameUnique
    private async Task<bool> IsNameUnique(string name, CancellationToken token)
    {
        _productService = _productService.Inject();
        var oldProductName = _productService.FirstOrDefault(user => user.Id == ProductId, u => new { u.Id, u.Name }).Response.Name;

        return await _productService.AnyAsync(x => x.Name == name && x.Name != oldProductName) == 0;
    }

    //IsBarcodUnique
    private async Task<bool> IsBarcodUnique(string barcode, CancellationToken token)
    {
        _productService = _productService.Inject();
        var oldProductBarcode = _productService.FirstOrDefault(user => user.Id == ProductId, u => new { u.Id, u.Barcode }).Response.Barcode;
        return await _productService.AnyAsync(x => x.Barcode == barcode && x.Barcode != "0" && !x.Barcode.IsNotNullOrEmpty() && x.Barcode != oldProductBarcode) == 0;
    }

    public bool SetProductId(int productId)
    {
        ProductId = productId;
        return true;
    }

}
