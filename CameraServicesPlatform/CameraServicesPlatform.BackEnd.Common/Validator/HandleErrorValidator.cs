using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using FluentValidation.Results;

namespace CameraServicesPlatform.BackEnd.Common.Validator;

public class HandleErrorValidator
{
    public AppActionResult HandleError(ValidationResult result)
    {
        if (!result.IsValid)
        {
            var errorMessage = new List<string>();
            foreach (var error in result.Errors) errorMessage.Add(error.ErrorMessage);
            return new AppActionResult
            {
                IsSuccess = false,
                Messages = errorMessage,
                Result = null
            };
        }

        return new AppActionResult();
    }
}