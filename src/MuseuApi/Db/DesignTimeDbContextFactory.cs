using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MuseuApi.Db
{
    public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<MuseuContext>
    {
        public MuseuContext CreateDbContext(string[] args)
        {
            return new MuseuContext();
        }
    }
}