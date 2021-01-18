using System;
using System.Collections.Generic;
using AutoMapper;
using HomeAssignmentLibrary.API.Models;
using HomeAssignmentLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomeAssignmentLibrary.API.Controllers
{
    [ApiController]
    [Route("api/customers/{customerId}/agreements/baseRateCode={newBaseRateCode}")]
    public class AgreementsController : ControllerBase
    {
        private readonly IHomeAssignmentLibraryRepository _homeAssignmentLibraryRepository;
        private readonly IMapper _mapper;

        public AgreementsController(IHomeAssignmentLibraryRepository homeAssignmentLibraryRepository, IMapper mapper)
        {
            _homeAssignmentLibraryRepository = homeAssignmentLibraryRepository ??
                                               throw new ArgumentNullException(nameof(homeAssignmentLibraryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ResponseDto>> GetAgreementsForCustomer(Guid customerId, string newBaseRateCode)
        {
            if (!_homeAssignmentLibraryRepository.CustomerExists(customerId))
            {
                return NotFound();
            }

            var customerAgreementsFromRepo = _homeAssignmentLibraryRepository.GetAgreements(customerId);

            foreach (var customerAgreement in customerAgreementsFromRepo)
            {
                customerAgreement.NewBaseRateCode = newBaseRateCode;
            }

            return Ok(_mapper.Map<IEnumerable<ResponseDto>>(customerAgreementsFromRepo));
        }
    }
}
