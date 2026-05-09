using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBLL.interfaces
{
    public interface ITicketBll
    {
        //get all ticket
        Task<List<TicketDTO>> getTicketsAsync();

        //get tickets by attraction
        Task<List<TicketDTO>> getTicketByAttrationAsync(int id);

        //get tickets by attraction
        Task<List<TicketDTO>> getTicketByEmployeeAsync(int id);

        //buy ticket
        Task<bool> buyTicketAsync(TicketDTO ticketDto);
    }
}
