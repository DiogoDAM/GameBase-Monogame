using System;

namespace GameBase;

public abstract class Scene : BaseActive
{
	public string Name;

	public Scene()
	{
	}

	public abstract void Start();
	public abstract void Update(Time time);
	public abstract void Draw();
}
