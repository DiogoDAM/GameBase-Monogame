using System.Collections.Generic;

namespace GameBase;

public abstract class ParticleModifier
{
	public bool IsEnabled;

	public ParticleModifier()
	{
		IsEnabled = true;
	}

	public abstract void UpdateParticles(Time time, List<Particle> particles);
}
