using MVC5.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5.Models.View
{
    public class TaskViewModel
    {
        public TaskViewModel() { }

        public TaskViewModel(TaskDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Date = dto.Date;
            Done = dto.Done;
            UserId = dto.UserId;
        }

        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Concluído")]
        public bool Done { get; set; }

        public int UserId { get; set; }

        public UserViewModel User { get; set; }
    }
}