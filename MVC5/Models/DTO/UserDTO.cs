using MVC5.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5.Models.DTO
{
    public class UserDTO
    {
        public UserDTO() { }

        public UserDTO(UserInputModel inputModel)
        {
            Name = inputModel.Name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public IList<TaskDTO> Tasks { get; set; }
    }
}