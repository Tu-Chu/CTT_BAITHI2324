using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CHUTHIENTU_639.Models;

public class Cau2
{
    [Key]

    public int ID { get; set; }

    public string Name { get; set; }

    public string Address   { get; set; }
}

