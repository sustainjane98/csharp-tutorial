namespace ExampleWebApplication.Interfaces;

public interface IMapper<T, TM>
{
    public T ToDto(TM category);
    public ICollection<T> ToDtos(ICollection<TM> category);
    public TM ToDao(T categoryDto);
    public ICollection<TM> ToDaos(ICollection<T> categoryDto);
}