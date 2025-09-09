using System;
using System.Collections.Generic;

namespace GameBase;

public abstract class Entity : BaseActive
{
	public uint Id;

	public List<Component> Components { get; protected set; }

	public EntityTransform Transform;

	public Scene Scene;

	public Entity()
	{
		Components = new();
		Transform = new();
	}

	public virtual void Start()
	{
		foreach(Component c in Components)
		{
			c.Start();
		}
	}

	public virtual void Update(Time time)
	{
		foreach(Component c in Components)
		{
			c.Update(time);
		}

		Components.RemoveAll(co => co.Disposed == true);
	}

	public virtual void Draw()
	{
		foreach(Component c in Components)
		{
			c.Draw();
		}
	}

	//Components Methods 
	public void AddComponents(Component c) 
	{
		Components.Add(c);
	}

	public bool RemoveComponents<T>() where T : Component
	{
		var c = Components.Find(co => co is T);

		if(c == null) return false;

		Components.Remove(c);
		return true;
	}

	public bool ContainsComponent<T>() where T : Component
	{
		return Components.Contains(Components.Find(c => c is T));
	}

	public T GetComponent<T>() where T : Component
	{
		return (T)Components.Find(c => c is T);
	}

	public bool TryGetComponent<T>(out Component c) where T : Component
	{
		var co = Components.Find(c => c is T);

		if(co == null) { c = null; return false; }
		else { c = co; return true; }
	}

	protected override void Dispose(bool disposable)
	{
		if(disposable)
		{
			if(!Disposed)
			{
				Desactivate();
				Components.Clear();
				Disposed = true;
			}
		}
	}

	public override string ToString() => $"(Id: {Id}, Scene{Scene.Name}, Transform: {Transform})";
}
