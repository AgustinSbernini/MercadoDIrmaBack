using System.ComponentModel.DataAnnotations;

public enum Role { Admin = 1, Usuario, Proveedor, Cliente }
public enum AppointmentStatus { Nuevo = 1, Cancelado, Reprogramado, Concretado }
public enum Day
{
    [Display(Name = "Domingo")]
    Domingo,
    [Display(Name = "Lunes")]
    Lunes,
    [Display(Name = "Martes")]
    Martes,
    [Display(Name = "Miércoles")]
    Miercoles,
    [Display(Name = "Jueves")]
    Jueves,
    [Display(Name = "Viernes")]
    Viernes,
    [Display(Name = "Sábado")]
    Sabado,
}
public enum TransactionType
{
    [Display(Name = "Compra")]
    Compra = 1,
    [Display(Name = "Pago")]
    Pago,
    [Display(Name = "Devolución")]
    Devolucion
}