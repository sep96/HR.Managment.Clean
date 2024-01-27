using HR.Managment.Application.Contracts.Email;
using HR.Managment.Application.Contracts.Logging;
using HR.Managment.Application.Model.Email;
using HR.Managment.Infrastructure.EmailSenderService;
using HR.Managment.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSetting>(configuration.GetSection("EmailSetting"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped(typeof(IAppLogger<>) , typeof(LoggerAdapter<>));
            return services;
        }
    }
}
