using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using to_do_app.Models;

namespace to_do_app.Models
{
    public class Task
    {
        public Task()
        {
            Status = "todo";
            Subtasks = new List<Subtask>();
        }

        [HiddenInput]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Description for task is required!")]
        public string Description { get; set; }

        [HiddenInput]
        public string Status { get; set; }

        [Required(ErrorMessage = "End date is required!")]
        public DateTime Deadline { get; set; }

        virtual public List<Subtask> Subtasks { get; set; }
    }
}
