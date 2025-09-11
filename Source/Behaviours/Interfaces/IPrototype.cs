namespace GameBase;

public interface IPrototype
{
	public IPrototype ShallowClone();
	public IPrototype DeepClone();
}
