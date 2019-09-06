using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;


namespace HA.DNS.Business.Tests
{
    public class DnsService_Test 
    {
        //private readonly DNSService _dnsService;
        public DnsService_Test()
        {
            
        }

        [Theory(DisplayName = "Calculate Data bank Location")]
        [InlineData(123.12, 456.56, 789.89, 20.0)]
        public void CalculateDataBankLocation_Test(double x, double y, double z, double vel)
        {
            //Arrange
            var _dnsService = new DNSService();

            //Act
            var result = _dnsService.CalculateDataBankLocation(x, y, z, vel).Result;

            //Assert
            Assert.Equal(1389.57, result);
        }
    }
}
