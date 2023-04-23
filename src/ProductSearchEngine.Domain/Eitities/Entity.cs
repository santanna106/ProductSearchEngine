using System.ComponentModel.DataAnnotations;

namespace ProductSearchEngine.Domain.Eitities
{
    public abstract class Entity
    {
        public int Id { get; set; }
    }
}