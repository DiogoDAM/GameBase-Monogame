using System.Collections.Generic;
using System;

namespace GameBase;

public sealed class RotationModifier : ParticleModifier
{
	public float RotationTarget;

	public RotationModifier(float target) : base()
	{
		RotationTarget = target;
	}

    public override void UpdateParticles(Time time, List<Particle> particles)
    {
		foreach(Particle p in particles)
		{
			p.Rotation = Math.Clamp(RotationTarget, p.Rotation, p.TimeAmount);
		}
    }
}
