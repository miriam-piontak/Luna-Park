using AutoMapper;
using DAL.Models;
using DTO;
using IDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DAL

{

    internal class AttractionDal : IAttractionDal
    {
        private readonly AmusementParkContext _context;//the mapper
        private readonly IMapper _mapper; // the DB

        public AttractionDal(IMapper mapper, AmusementParkContext context )
        {
            this._mapper = mapper;
            this._context = context;
        }

        // Method to retrieve all attractions
        public async Task<List<AttractionDTO>> GetAllAttractionsAsync()
        {
            var attractionDal = _context.Attractions.ToList();
            var attractionDto = _mapper.Map<List<AttractionDTO>>(attractionDal);
            return attractionDto;
        }

        //get attraction by id
        public async Task<AttractionDTO> GetAttractionByIdAsync(int id)
        {
            var attractionDal = await _context.Attractions.FirstOrDefaultAsync(x => x.AttractionId == id);
            var attractionDto = _mapper.Map<AttractionDTO>(attractionDal);
            return attractionDto;
        }
        //upate attraction
        public async Task UpdateAttractionAsync(AttractionDTO attraction)
        {
            var attractionDal = _mapper.Map<Attraction>(attraction);
            _context.Attractions.Update(attractionDal);
            await _context.SaveChangesAsync();

        }
        //delete attraction from DB
        public async Task DeleteAttractionAsync(int id)
        {
            var id2 = await _context.Attractions.FindAsync(id);
            if(id2!=null)
            {
                _context.Attractions.Remove(id2);
                await _context.SaveChangesAsync();
            }
        }
        //add attraction to DB
        public async Task CreateAttractionAsync(AttractionDTO attraction)
        {
            var attractionDal = _mapper.Map<Attraction>(attraction);
            await _context.Attractions.AddAsync(attractionDal);
            await _context.SaveChangesAsync();

        }

    }
}
