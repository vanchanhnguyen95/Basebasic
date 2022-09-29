namespace Aya.Infrastructure.Base
{
    public interface IPersistentEntity
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedAt { get; set; }
    }
}
