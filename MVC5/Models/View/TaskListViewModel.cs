using MVC5.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5.Models.View
{
    public class TaskListViewModel
    {
        public TaskListViewModel() { }

        public TaskListViewModel(UserDTO userDTO, IEnumerable<TaskDTO> tasksDTO)
        {
            User = new UserViewModel()
            {
                Id = userDTO.Id,
                Name = userDTO.Name
            };

            Tasks = tasksDTO.Select(x =>
                new TaskViewModel()
                {
                    Date = x.Date,
                    Done = x.Done,
                    Id = x.Id,
                    Name = x.Name
                }
            ).ToList();
        }

        public UserViewModel User { get; set; }

        public List<TaskViewModel> Tasks { get; set; }
    }
}