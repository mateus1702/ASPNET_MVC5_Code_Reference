using MVC5.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5.Models.View
{
    public class UserViewModel
    {
        public UserViewModel() { }

        public UserViewModel(UserDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Tasks = dto.Tasks != null ?
                dto.Tasks.Select(x => new TaskViewModel(x)).ToList() :
                new List<TaskViewModel>();
        }

        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }


        public IList<TaskViewModel> Tasks { get; set; }
    }
}