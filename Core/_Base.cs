using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class _Base<T>
    {
        [Key]
        [Column(Order = 0)]
        public T Id { get; set; }
        //====================================================================================================
        public DateTime CreatedAt { get; set; }
        //====================================================================================================
        public DateTime UpdatedAt { get; set; }
        //====================================================================================================
        public bool IsDeleted { get; set; }
        //====================================================================================================
    }
}
