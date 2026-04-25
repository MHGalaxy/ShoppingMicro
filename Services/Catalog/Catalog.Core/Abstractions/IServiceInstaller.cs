using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Core.Abstractions;

public interface IServiceInstaller
{
    void Install(IServiceCollection services, IConfiguration configuration);
}
