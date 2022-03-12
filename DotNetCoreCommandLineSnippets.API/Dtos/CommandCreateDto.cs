using System.ComponentModel.DataAnnotations;
namespace DotNetCoreCommandLineSnippets.API.Dtos
{
 public class CommandCreateDto
 {
 [Required]
 [MaxLength(250)]
 public string HowTo { get; set; }
 [Required]
 public string Platform { get; set; }
 [Required]
 public string CommandLine { get; set; }
 }
}