using Mapster;
using SnackJobs.Api.Models.Application.Given;
using SnackJobs.Api.Tiers.Business.Abstract;
using SnackJobs.Api.Tiers.Business.Helper;
using SnackJobs.Api.Tiers.Business.Responses;
using SnackJobs.Api.Tiers.Business.Responses.Application;
using SnackJobs.Api.Tiers.Core.Applications;
using SnackJobs.Api.Tiers.Data;
using SnackJobs.Api.Tiers.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Business.Concrete
{
    public class GivenApplicationManager : IGivenApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IGivenApplicationDal _givenApplicationDal;
        private IDoneApplicationDal _doneApplicationDal;
        public GivenApplicationManager(IUnitOfWork unitOfWork, IGivenApplicationDal givenApplicationDal, IDoneApplicationDal doneApplicationDal)
        {
            _unitOfWork = unitOfWork;
            _givenApplicationDal = givenApplicationDal;
            _doneApplicationDal = doneApplicationDal;
        }

        public async Task<BasexResponse<IEnumerable<DoneApplicationWithUserResponse>>> GetApplicationWithDoneAppsDetail(Guid givenApplicationId)
        {
            try
            {
                var response = await  _doneApplicationDal.GetByGivenAppIdWithUserAsync(givenApplicationId);

                return new BasexResponse<IEnumerable<DoneApplicationWithUserResponse>>(response.Adapt<IEnumerable<DoneApplicationWithUserResponse>>());
            }
            catch (Exception ex)
            {

                return new BasexResponse<IEnumerable<DoneApplicationWithUserResponse>>(ex.Message);
            }
        }

        public async Task<BasexResponse<IEnumerable<GivenApplicationWithDoneApplicationResponse>>> GetApplications(Guid userId)
        {
            try
            {
                var response = await _givenApplicationDal.GetByUserIdWithDoneApplicationsAsync(userId);
               
                return new BasexResponse<IEnumerable<GivenApplicationWithDoneApplicationResponse>>(response.Adapt<IEnumerable<GivenApplicationWithDoneApplicationResponse>>());
            }
            catch (Exception ex)
            {

                return new BasexResponse<IEnumerable<GivenApplicationWithDoneApplicationResponse>>(ex.Message);
            }
        }

        public async Task<BasexResponse<IEnumerable<GivenApplicationByDistanceResponse>>> GetApplicationsByDistance(ApplicationsByDistance model)
        {
            try
            {
                var response = await _givenApplicationDal.GetBySearchTermWithLocationAsync(model.SearchTerm);
                List<GivenApplicationByDistanceResponse> givenApplications = new List<GivenApplicationByDistanceResponse>();

                double modelLat = model.Lat,
                       modelLon = model.Lon;
                double appLat, appLon, distance;
                foreach (var item in response)
                {
                    appLat = item.User.Location.Lat;
                    appLon = item.User.Location.Lon;
                    distance = GFG.distance(appLat, appLon, modelLat, modelLon);

                    if (distance <= model.MaxDistance) {
                        var selected = item.Adapt<GivenApplicationByDistanceResponse>();
                        selected.DistanceBetweenApplicationAndMe = distance;
                        givenApplications.Add(selected);
                    }
                }
                return new BasexResponse<IEnumerable<GivenApplicationByDistanceResponse>>(givenApplications.OrderBy(x=>x.DistanceBetweenApplicationAndMe));

            }
            catch (Exception ex)
            {
                return new BasexResponse<IEnumerable<GivenApplicationByDistanceResponse>>(ex.Message);
            }
        }

        public async Task<BasexResponse<GivenApplication>> RegisterApplicationAsync(GivenApplication givenApplication)
        {
            try
            {
                givenApplication.IsActive = true;
                var dbGivenApplication = await _givenApplicationDal.AddAsync(givenApplication);
                await _unitOfWork.CompleteAsync();
                return new BasexResponse<GivenApplication>(dbGivenApplication);
            }
            catch (Exception ex)
            {
                return new BasexResponse<GivenApplication>(ex.Message);
            }
        }

        public async Task<BasexResponse<GivenApplicationWithUserResponse>> GetPublicGivenApplicationDetailAsync(Guid id)
        {
            try
            {
                var response = await _givenApplicationDal.GetByIdWithUserAndLocationAsync(id);

                return new BasexResponse<GivenApplicationWithUserResponse>(response.Adapt<GivenApplicationWithUserResponse>());
            }
            catch (Exception ex)
            {
                return new BasexResponse<GivenApplicationWithUserResponse>(ex.Message);
            }
        }
    }
}
