using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;

namespace GameBase;

public sealed class Particle : IDisposable
{
	public Vector2 Position { get; private set; }

	public Vector2 Velocity;

	public float Angle;

	public float Rotation;

	public Vector2 Origin;

	public Vector2 Scale = Vector2.One;

	public float TimeAmount { get; private set; }

	public Color Color = Color.White;

	public bool Die;

	public SpriteEffects Flip;

	public float Depth;

	public float LifeTime;

	public float CurrentLifeTime { get; private set; }

	public Particle(Vector2 pos, float lifeTime)
	{
		Position = pos;
		LifeTime = lifeTime;
		CurrentLifeTime = LifeTime;
	}

	public void Update(Time time)
	{
		if(!Die)
		{
			CurrentLifeTime -= time.DeltaTime;

			TimeAmount = CurrentLifeTime * 1f / LifeTime;

			if(CurrentLifeTime <= 0) { Die = true; Dispose(); }

			Vector2 dir = new((float)Math.Cos(Angle), (float)Math.Sin(Angle));
			Position += dir * Velocity * time.DeltaTime;
		}
	}

	public void Dispose()
	{
		if(Die)
		{
			GC.SuppressFinalize(this);
		}
	}
}
