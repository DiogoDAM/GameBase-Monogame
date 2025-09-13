using System.Collections.Generic;

namespace GameBase;

public class ParticleEmitter
{
	public List<Particle> Particles { get; protected set; }

	public List<ParticleModifier> Modifiers { get; protected set; }

	public ParticleStarter Starter { get; set; }

	public float Interval { get; private set; }
	protected float m_currentInteval;

	public TextureRegion2D Region;

	public ParticleEmitter(TextureRegion2D region)
	{
		Region = region;
		Particles = new();
		Modifiers = new();
	}

	public ParticleEmitter(TextureRegion2D region, float interval)
	{
		Region = region;
		Particles = new();
		Modifiers = new();

		Interval = interval;
		m_currentInteval = Interval;
	}

	public void AddInterval(float interval)
	{
		Interval = interval;
		m_currentInteval = Interval;
	}

	public void AddParticle()
	{
		Particle p = Starter.CreateParticle();

		Particles.Add(p);
	}

	public void Emit(uint amount)
	{
		for(uint i=0; i<amount; i++)
		{
			AddParticle();
		}
	}

	public void EmitInterval(Time time)
	{
		m_currentInteval -= time.DeltaTime;

		while(m_currentInteval <= 0)
		{
			m_currentInteval += Interval;

			AddParticle();
		}
	}

	public void Update(Time time)
	{
		foreach(Particle p in Particles)
		{
			p.Update(time);
		}

		Particles.RemoveAll(p => p.Die == true);

		foreach(ParticleModifier mod in Modifiers)
		{
			mod.UpdateParticles(time, Particles);
		}

	}

	public void Draw()
	{
		foreach(Particle p in Particles)
		{
			Core.SpriteBatch.Draw(Region.Texture, p.Position, Region.SourceRectangle, p.Color, p.Rotation, p.Origin, p.Scale, p.Flip, p.Depth);
		}
	}
}
