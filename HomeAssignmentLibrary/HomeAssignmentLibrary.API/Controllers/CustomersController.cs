using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using AutoMapper;
using HomeAssignmentLibrary.API.Entities;
using HomeAssignmentLibrary.API.Models;
using HomeAssignmentLibrary.API.Services;

namespace HomeAssignmentLibrary.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly IHomeAssignmentLibraryRepository _homeAssignmentLibraryRepository;
        private readonly IMapper _mapper;

        public CustomersController(IHomeAssignmentLibraryRepository homeAssignmentLibraryRepository, IMapper mapper)
        {
            _homeAssignmentLibraryRepository = homeAssignmentLibraryRepository ??
                                               throw new ArgumentNullException(nameof(homeAssignmentLibraryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public ActionResult<IEnumerable<CustomerDto>> GetAuthors()
        {
            var customersFromRepo = _homeAssignmentLibraryRepository.GetCustomers();

            return Ok(_mapper.Map<IEnumerable<CustomerDto>>(customersFromRepo));
        }

        [HttpGet("{customerId}")]
        public IActionResult GetCustomer(Guid customerId)
        {
            var customerFromRepo = _homeAssignmentLibraryRepository.GetCustomer(customerId);

            if (customerFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CustomerDto>(customerFromRepo));
        }
    }
}
