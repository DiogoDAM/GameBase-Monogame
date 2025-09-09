using System;

namespace GameBase;

public abstract class BaseActive : IDisposable
{
	public bool IsActive { get; set; }
	public bool IsDrawable { get; set; }
	public bool Disposed { get; protected set; }

	public virtual void Activate()
	{
		IsActive = true;
		IsDrawable = true;
	}

	public virtual void Desactivate()
	{
		IsActive = false;
		IsDrawable = false;
	}

	public bool CheckActive()
	{
		return IsActive && !Disposed;
	}
	public bool CheckDrawable()
	{
		return IsDrawable && !Disposed;
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	protected abstract void Dispose(bool disposable);
}
