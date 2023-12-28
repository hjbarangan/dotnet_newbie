using System.ComponentModel.DataAnnotations;


namespace dotnet_newbie.Models;

public class Role
{
    public int Id { get; set; }
    public string? Name { get; set; }

   [Display(Name = "Date Created")]
   [DataType(DataType.Date)]
    public DateTime CreatedAt { get; set; }


}