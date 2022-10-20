using Mapster;
using SnackJobs.Api.Models.Adress;
using SnackJobs.Api.Tiers.Business.Abstract;
using SnackJobs.Api.Tiers.Business.Responses;
using SnackJobs.Api.Tiers.Core;
using SnackJobs.Api.Tiers.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Business.Concrete
{
    public class LocationManager : ILocationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private ILocationDal _locationDal;
        public LocationManager(IUnitOfWork unitOfWork, ILocationDal locationDal)
        {
            _unitOfWork = unitOfWork;
            _locationDal = locationDal;
        }

        public async Task<BasexResponse<Location>> CreateAsync(Location location)
        {
            try
            {
                var exist = await _locationDal.FindAsync(x => x.UserId == location.UserId);

                if (exist == null)
                    exist = await _locationDal.AddAsync(location);
                else 
                {
                    exist.Lat = location.Lat;
                    exist.Lon = location.Lon;
                    exist.Title = location.Title;
                }

                await _unitOfWork.CompleteAsync();
                return new BasexResponse<Location>(exist);
            }
            catch (Exception ex)
            {
                return new BasexResponse<Location>(ex.Message);
            }
        }

        public async Task<BasexResponse<GeneralLocationResponse>> GetByUserIdAsync(Guid userId)
        {
            try
            {
                var response = await _locationDal.FindAsync(x => x.UserId == userId);
                return new BasexResponse<GeneralLocationResponse>(response.Adapt<GeneralLocationResponse>());
            }
            catch (Exception ex)
            {
                return new BasexResponse<GeneralLocationResponse>(ex.Message);
            }
        }
    }
}
