#if NET5_0_OR_GREATER
namespace PowerUtils.BuildingBlocks.Domain
{
    public abstract record ValueObjectRBase : IValueObjectBase
    {
        public virtual void Validate() { }
    }
}
#endif
