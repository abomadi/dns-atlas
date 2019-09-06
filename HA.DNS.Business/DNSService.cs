using System;
using System.Threading;
using System.Threading.Tasks;
using HA.DNS.Models;

namespace HA.DNS.Business
{
    public class DNSService
    {
        private const int sectorId = 1;

        public DNSService()
        {
        }

        public async Task<DnsResponse> GetDataBankLocation(DnsRequest coords, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                var calculatedLocation = await CalculateDataBankLocation(coords.X, coords.Y, coords.Z, coords.Velocity,cancellationToken).ConfigureAwait(false);
                var location = new DnsResponse(calculatedLocation);
                return await Task.FromResult(location);
            }
            catch(Exception ex)
            {
                //_logger.LogError($"Error calculating data location {ex.Message});
                throw new Exception(ex.Message);

            }
        }

        public async Task<double> CalculateDataBankLocation(double x, double y, double z, double velocity, CancellationToken cancellationToken = default(CancellationToken))
        {

            try
            {
                double loc = (x * sectorId) + (y * sectorId) + (z * sectorId) + velocity;
                loc = Math.Round(loc,2);
                return await Task.FromResult(loc);

            }
            catch(OverflowException ex)
            {
                //log error + params
                return await Task.FromResult(0);
            }
            catch(Exception ex)
            {
                //log error + params
                return await Task.FromResult(0);
            }
            
        }
       
    }
}
