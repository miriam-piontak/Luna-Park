using AutoMapper;
using DAL.Models;
using DTO;

namespace DAL
{
    public class MappingProfile:Profile
    {
        //casting attraction to attractionDTO
        public static AttractionDTO Attraction_to_dto(Attraction attraction)
        {

            return new AttractionDTO
            {
                AttractionId = attraction.AttractionId,
                AttractionName = attraction.AttractionName,
                MaxCapacity = attraction.MaxCapacity
            };
        }
        //casting attractionDTO to attraction
        public static Attraction Attractiondto_to_Attraction(AttractionDTO attractionDTO)
        {

            return new Attraction
            {
                AttractionId = attractionDTO.AttractionId,
                AttractionName = attractionDTO.AttractionName,
                MaxCapacity = attractionDTO.MaxCapacity
            };
        }
        //casting employee to employeeDTO
        public static DTO.EmployeeDTO Employee_to_dto(Models.Employee employee)
        {
            return new DTO.EmployeeDTO
            {
                EmployeeTz = employee.EmployeeTz,
                FullName = employee.EmployeeFirstName + " " + employee.EmployeeLastName,
                AttractionId = employee.AttractionId,
                AttractionName = employee.Attraction?.AttractionName ?? "ללא מתקן"
            };
        }
        //casting employeeDTO to employee
        public static Models.Employee EmployeeDTO_to_Employee(DTO.EmployeeDTO employeeDTO)
        {
            string[] names = employeeDTO.FullName.Split(' ');
            string firstName = "";
            for (int i = 0; i < names.Length - 1; i++)
            {
                firstName += names[i] + " ";
            }
            return new Models.Employee
            {
                EmployeeTz = employeeDTO.EmployeeTz,
                EmployeeFirstName = firstName.Trim(),
                EmployeeLastName = names[names.Length - 1],
                AttractionId = employeeDTO.AttractionId,
                Attraction = null!
            };
        }
        //casting ticket to ticketDTO
        public static TicketDTO Ticket_to_dto(Ticket ticket)
        {
            return new TicketDTO
            {
                TicketStartDateTime = ticket.TicketStartDateTime,
                TicketId = ticket.TicketId,
                TicketPrice = ticket.TicketPrice,

                AttractionId = ticket.AttractionId,
                AttractionName = ticket.Attraction?.AttractionName ?? "ללא מתקן",

                EmployeeId = ticket.EmployeeId,
                SellerName = ticket.Employee != null ? ticket.Employee.EmployeeFirstName + " " + ticket.Employee.EmployeeLastName : "ללא עובד",
            };
        }

        //casting ticketDTO to ticket
        public static Ticket TicketDTO_to_Ticket(TicketDTO ticketDTO)
        {
            return new Ticket
            {
                TicketStartDateTime= ticketDTO.TicketStartDateTime,
                TicketId = ticketDTO.TicketId,
                TicketPrice = ticketDTO.TicketPrice,
                AttractionId = ticketDTO.AttractionId,
                EmployeeId = ticketDTO.EmployeeId
            };
        }

    }
}
