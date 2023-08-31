using System.ComponentModel.DataAnnotations;

public enum Role { Admin = 1, Usuario, Proveedor, Cliente }
public enum AppointmentStatus { Nuevo = 1, Cancelado, Reprogramado, Concretado }
public enum Day
{
    [Display(Name = "Lunes")]
    Lunes = 1,
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
    [Display(Name = "Domingo")]
    Domingo
}