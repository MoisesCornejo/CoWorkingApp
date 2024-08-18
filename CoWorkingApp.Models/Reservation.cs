namespace CoWorkingApp.Models;

public class Reservation // clase reservación
{
    public Guid ReservationId { get; set; }
    public DateTime ReservationDate { get; set; } // fecha reservación
    public Guid DeskId { get; set; } // id escritorio
    public Guid UserId { get; set; } // id usuario
}