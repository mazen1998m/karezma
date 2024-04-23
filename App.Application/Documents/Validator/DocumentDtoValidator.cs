using App.Domain.Documents.Dtos;
using FluentValidation;

namespace App.Application.Documents.Validator;

public class DocumentDtoValidator : AbstractValidator<CreateDocumentDto>
{
    public DocumentDtoValidator()
    {

    }
}
