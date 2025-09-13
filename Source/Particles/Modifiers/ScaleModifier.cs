using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GameBase;

public sealed class ScaleModifier : ParticleModifier
{
	public Vector2 TargetScale;

	public ScaleModifier(Vector2 target) : base()
	{
		TargetScale = target;
	}

    public override void UpdateParticles(Time time, List<Particle> particles)
    {
		foreach(Particle p in particles)
		{
			p.Scale = Vector2.Lerp(TargetScale, p.Scale, p.TimeAmount);
		}
    }
}
