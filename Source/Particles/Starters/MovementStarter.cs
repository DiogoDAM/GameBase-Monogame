using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GameBase;

public sealed class MovementStarter : ParticleStarter
{
	public Vector2 StartPosition;

	public Vector2 MinVelocity;
	public Vector2 MaxVelocity;
	public float MinAngle;
	public float MaxAngle;

	public float LifeTime;

	public MovementStarter(ParticleEmitter emitter) : base(emitter)
	{
	}

	public override Particle CreateParticle()
	{
		Particle p = new(StartPosition, LifeTime);
		p.Velocity = new Vector2(Utilities.RandomFloat(MinVelocity.X, MaxVelocity.X), Utilities.RandomFloat(MinVelocity.Y, MaxVelocity.Y));
		p.Angle = Utilities.RandomFloat(MinAngle, MaxAngle);

		return p;
	}
}
