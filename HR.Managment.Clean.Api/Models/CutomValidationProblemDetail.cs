using Microsoft.AspNetCore.Mvc;

namespace HR.Managment.Clean.Api.Models
{
    public class CutomValidationProblemDetail : ProblemDetails
    {
        IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}
