using Microsoft.EntityFrameworkCore;
using TheHandymanOfCapeCod.Infrastructure.Data;

namespace TheHandymanOfCapeCod.Tests.Mocks
{
    public static class DatabaseMock
    {
        public static TheHandymanOfCapeCodDb Instance { 
            get 
            {
                var dbContextOptions = new DbContextOptionsBuilder<TheHandymanOfCapeCodDb>()
                    .UseInMemoryDatabase("TheHandymanOfCapeCodInMemoryDb"
                    + DateTime.Now.Ticks.ToString())
                    .Options;

                return new TheHandymanOfCapeCodDb(dbContextOptions, false);
            } 
        }
    }
}
