using Mapster;
using SnackJobs.Api.Models.Application.Done;
using SnackJobs.Api.Tiers.Business.Abstract;
using SnackJobs.Api.Tiers.Business.Responses;
using SnackJobs.Api.Tiers.Business.Responses.Application;
using SnackJobs.Api.Tiers.Core.Applications;
using SnackJobs.Api.Tiers.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Business.Concrete
{
    public class DoneApplicationManager : IDoneApplicationService
    {
        private IDoneApplicationDal _doneApplicationDal;
        private readonly IUnitOfWork _unitOfWork;
        public DoneApplicationManager(IUnitOfWork unitOfWork, IDoneApplicationDal doneApplicationDal)
        {
            _doneApplicationDal = doneApplicationDal;
            _unitOfWork = unitOfWork;
        }

        public async Task<BasexResponse<DoneApplication>> MakeApplicationAsync(DoneApplication doneApplication)
        {
            try
            {
                var exist = await _doneApplicationDal.GetByCompositeKeys(doneApplication.UserId, doneApplication.GivenApplicationId);
                if(exist!=null)
                    return new BasexResponse<DoneApplication>("You already applied this application");

                doneApplication.DoneApplicationType = DoneApplicationType.Pending;
                var dbDoneApplication = await _doneApplicationDal.AddAsync(doneApplication);
                await _unitOfWork.CompleteAsync();
                return new BasexResponse<DoneApplication>(dbDoneApplication);
            }
            catch (Exception ex)
            {
                return new BasexResponse<DoneApplication>(ex.Message.FirstOrDefault().ToString());
            }
        }

        public async Task<BasexResponse<DoneApplication>> DenyApplicationAsync(DoneApplication doneApplication)
        {
            try
            {
                var doneApplicationEntity = await _doneApplicationDal.GetByCompositeKeys(doneApplication.UserId, doneApplication.GivenApplicationId);

                doneApplicationEntity.DoneApplicationType = DoneApplicationType.Denied;

                var updatedDoneApplication = await _doneApplicationDal.UpdateAsync(doneApplicationEntity);
                await _unitOfWork.CompleteAsync();
                return new BasexResponse<DoneApplication>(updatedDoneApplication);
            }
            catch (Exception ex)
            {
                return new BasexResponse<DoneApplication>(ex.Message);
            }
        }

        public async Task<BasexResponse<DoneApplication>> AcceptApplicationAsync(DoneApplication doneApplication)
        {
            try
            {
                var doneApplicationEntity = await _doneApplicationDal.GetByCompositeKeys(doneApplication.UserId, doneApplication.GivenApplicationId);

                doneApplicationEntity.DoneApplicationType = DoneApplicationType.Accepted;

                var updatedDoneApplication = await _doneApplicationDal.UpdateAsync(doneApplicationEntity);
                await _unitOfWork.CompleteAsync();
                return new BasexResponse<DoneApplication>(updatedDoneApplication);
            }
            catch (Exception ex)
            {
                return new BasexResponse<DoneApplication>(ex.Message);
            }
        }
        public async Task<BasexResponse<DoneApplication>> CompleteApplicationAsync(DoneApplication doneApplication)
        {
            try
            {
                var doneApplicationEntity = await _doneApplicationDal.GetByCompositeKeys(doneApplication.UserId, doneApplication.GivenApplicationId);

                doneApplicationEntity.DoneApplicationType = DoneApplicationType.Completed;
                doneApplicationEntity.Comment = doneApplication.Comment;
                doneApplicationEntity.Vote = doneApplication.Vote;

                var updatedDoneApplication = await _doneApplicationDal.UpdateAsync(doneApplicationEntity);
                await _unitOfWork.CompleteAsync();
                return new BasexResponse<DoneApplication>(updatedDoneApplication);
            }
            catch (Exception ex)
            {
                return new BasexResponse<DoneApplication>(ex.Message);
            }
        }
        public async Task<BasexResponse<IEnumerable<DoneApplicationWithGivenApplicationResponse>>> GetApplicationsAsync(Guid userId)
        {
            try
            {
                var response = await _doneApplicationDal.GetByUserIdWithGivenApplicationAsync(userId);
                var adapted = response.Adapt<IEnumerable<DoneApplicationWithGivenApplicationResponse>>();
                return new BasexResponse<IEnumerable<DoneApplicationWithGivenApplicationResponse>> (adapted);
            }
            catch (Exception ex)
            {

                return new BasexResponse<IEnumerable<DoneApplicationWithGivenApplicationResponse>>(ex.Message);
            }
        }

       
    }
}
