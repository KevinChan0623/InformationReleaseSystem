using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InformationReleaseSystem.Models
{
    [Table("sort")]
    public class Sort
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
