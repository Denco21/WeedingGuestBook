using System.ComponentModel.DataAnnotations;


namespace BlazorMessageWall.Models
{
	public class PersonModel
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(50, ErrorMessage = "Name is too long.")]

		public string? FirstName { get; set; }

		public string? LastName { get; set; } 

		public string? Email { get; set; }

        public string? PhoneNumber { get; set; } 

		public string? Message { get; set; } 
    }
}
