using MVC5.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5.Models.Input
{
    public class UserInputModel
    {
        public UserInputModel() { }

        public UserInputModel(UserDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
        }

        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo nome obrigatório.")]
        public string Name { get; set; }
    }
}