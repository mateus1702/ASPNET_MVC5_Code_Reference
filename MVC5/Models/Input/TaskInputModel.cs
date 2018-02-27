using MVC5.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5.Models.Input
{
    public class TaskInputModel
    {
        public TaskInputModel() { }

        public TaskInputModel(TaskDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Date = dto.Date;
            Done = dto.Done;
            UserId = dto.UserId;
        }

        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo nome obrigatório.")]
        public string Name { get; set; }

        [Display(Name = "Data")]
        [Required(ErrorMessage = "Campo data obrigatório.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Concluído")]
        [Required(ErrorMessage = "Campo concluído obrigatório.")]
        public bool Done { get; set; }

        public int UserId { get; set; }
    }
}