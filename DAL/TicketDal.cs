using AutoMapper;
using DAL.Models;
using DTO;
using IDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    internal class TicketDal : ITicketDal
    {
        private readonly AmusementParkContext _context;//the DB
        private readonly IMapper _mapper; // the mapper

        public TicketDal(IMapper mapper, AmusementParkContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }        

        //add ticket to DB
        public async Task CreateTicketAsync(TicketDTO ticket)
        {
            var ticketDal = _mapper.Map<Ticket>(ticket);
            await _context.Tickets.AddAsync(ticketDal);
            await _context.SaveChangesAsync();
        }

        //delete ticket from DB
        public async Task DeleteTicketAsync(int id)
        {
            var id2 = await _context.Tickets.FindAsync(id);
            if(id2!=null)
            {
                _context.Tickets.Remove(id2);
                await _context.SaveChangesAsync();
            }

        }
        //get tickets by attraction_id
        public async Task<List<TicketDTO>> GetAllTicketsByAttractionAsync(int id)
        {
            var ticketsFromDB = await _context.Tickets.Where(x => x.AttractionId == id).ToListAsync();
            var tickesList = _mapper.Map<List<TicketDTO>>(ticketsFromDB);
            return tickesList;
        }

        //update ticket
        public async Task UpdateTicketAsync(TicketDTO ticket)
        {
            var ticketDal = _mapper.Map<Ticket>(ticket);
             _context.Tickets.Update(ticketDal);
            await _context.SaveChangesAsync();
        }
    }
}
