using System.ComponentModel.DataAnnotations;

namespace ProductSearchEngine.Domain
{
    public abstract class Entity
    {
        public int Id { get; set; }
    }
}