using FluentValidation.Results;

namespace HR.Managment.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public List<string> ValidationsError { get; set; }
        public BadRequestException(string message) : base(message)
        {

        }
        public BadRequestException(string message , ValidationResult validationResult) : base(message)
        {
            ValidationsError = new();
            foreach(var error in validationResult.Errors)
            {
                ValidationsError.Add(error.ErrorMessage);
            }
        }
    }

}
