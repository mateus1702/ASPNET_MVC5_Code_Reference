using MVC5.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5.Models.View
{
    public class UserListViewModel
    {
        public UserListViewModel() { }

        public UserListViewModel(UserDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
        }

        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }
    }
}