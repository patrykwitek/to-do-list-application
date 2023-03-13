using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace to_do_app.Models
{
    public class Subtask
    {
        public Subtask()
        {
            Status = "todo";
        }

        [HiddenInput]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Description for task is required!")]
        public string Description { get; set; }

        public string Status { get; set; }

        public Task? Task { get; set; }

        [HiddenInput]
        public int TaskId { get; set; }
    }
}
