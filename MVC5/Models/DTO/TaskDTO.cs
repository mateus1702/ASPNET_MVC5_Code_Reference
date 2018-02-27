using MVC5.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5.Models.DTO
{
    public class TaskDTO
    {
        public TaskDTO() { }

        public TaskDTO(TaskInputModel input)
        {
            Id = input.Id;
            Name = input.Name;
            Date = input.Date;
            Done = input.Done;
            UserId = input.UserId;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public bool Done { get; set; }

        public int UserId { get; set; }
    }
}