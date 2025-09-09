namespace GameBase;

public abstract class Component : BaseActive
{
	public Entity Entity;

	public Component(Entity e)
	{
		Entity = e;
	}

	public abstract void Start();

	public abstract void Update(Time time);

	public abstract void Draw();

	protected override void Dispose(bool disposable)
	{
		if(disposable)
		{
			if(!Disposed)
			{
				Desactivate();
				Disposed = true;
			}
		}
	}
}
