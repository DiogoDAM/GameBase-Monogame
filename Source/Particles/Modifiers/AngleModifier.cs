using System.Collections.Generic;
using System;

namespace GameBase;

public sealed class AngleModifier : ParticleModifier
{
	public float AngleTarget; 

	public AngleModifier(float target) : base()
	{
		AngleTarget = target;
	}

    public override void UpdateParticles(Time time, List<Particle> particles)
    {
		foreach(Particle p in particles)
		{
			p.Angle = Math.Clamp(AngleTarget, p.Angle, p.TimeAmount);
		}
    }
}
