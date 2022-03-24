using System.ComponentModel.DataAnnotations;

namespace DotNet6API_.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El titulo es requerido.")]
        public string Title { get; set; }

        [Required(ErrorMessage ="La descripcion es requerida.")]
        public string Description { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;

    }
}