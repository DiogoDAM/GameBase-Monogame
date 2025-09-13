using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GameBase;

public sealed class ColorModifier : ParticleModifier
{
	public Color TargetColor;

	public ColorModifier(Color target) : base()
	{
		TargetColor = target;
	}

    public override void UpdateParticles(Time time, List<Particle> particles)
    {
		foreach(Particle p in particles)
		{
			p.Color = Color.Lerp(TargetColor, p.Color, p.TimeAmount);
		}
    }
}
