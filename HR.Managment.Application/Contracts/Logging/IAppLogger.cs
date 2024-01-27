using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Application.Contracts.Logging
{
    public interface IAppLogger<T>
    {
        Task LogInformation(string message, params object[] args);
        Task LogWarning(string message, params object[] args);

    }
}
