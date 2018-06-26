using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RentAMovie.Dtos;
using RentAMovie.Models;
using System.Data.Entity;


namespace RentAMovie.Controllers.Api
{
    public class RentalsController : ApiController
    {

        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/rentals
        public IHttpActionResult GetRentals(string query = null)
        {
            var rentalsQuery = _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Movie);

            var rentalDtos = rentalsQuery
                .ToList()
                .Select(Mapper.Map<Rental, RentalDto>);

            return Ok(rentalDtos);
        }

        // GET /api/rentals/1
        public IHttpActionResult GetRental(int id)
        {
            var rental = _context.Rentals.SingleOrDefault(r => r.Id == id);

            if (rental == null)
                return NotFound();

            return Ok(Mapper.Map<Rental, RentalDto>(rental));
        }
    }
}