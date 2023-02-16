using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TodoListAPI.Models;

public class TodoItem
{
    [Key]
    public int ItemId { get; set; }

    [Required]
    [Column(TypeName = "varchar")]
    [StringLength(40)]
    public string TaskName { get; set; }

    [Column(TypeName = "varchar")]
    [StringLength(50)]
    public string Description { get; set; }

}
