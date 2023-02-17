using Microsoft.EntityFrameworkCore.Design;
using MySql.EntityFrameworkCore.Extensions;

namespace Prac1.Services
{
    public class MysqlEntityFrameworkDesignTimeServices : IDesignTimeServices
    {
        public MysqlEntityFrameworkDesignTimeServices()
        {
        }

        public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddEntityFrameworkMySQL();
            new EntityFrameworkRelationalDesignServicesBuilder(serviceCollection)
                .TryAddCoreServices();
        }
    }
}
