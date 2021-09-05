namespace Sample.Model
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
