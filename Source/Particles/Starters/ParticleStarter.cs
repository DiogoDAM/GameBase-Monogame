namespace GameBase;

public abstract class ParticleStarter
{
	protected ParticleEmitter m_emitter;

	public ParticleStarter(ParticleEmitter emitter)
	{
		m_emitter = emitter;
		m_emitter.Starter = this;
	}

	public abstract Particle CreateParticle();
}
