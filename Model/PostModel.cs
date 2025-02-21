using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pinterestapi.Model;

public class PostModel
{
    public PostModel() { }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }
    
    [StringLength(10485760)]
    public string Title { get; set; } = string.Empty;
    
    [MaxLength(10485760)]
    public string ImageBase64 { get; set; } = string.Empty;
    
    [MaxLength(255)]
    public string FileName { get; set; } = string.Empty;
    
    [MaxLength(10)]
    public string FileExtension { get; set; } = string.Empty;
    
    [MaxLength(10485760)]
    public string ImageUrl { get; set; } = string.Empty;
}