using Microsoft.Xna.Framework;

namespace GameBase;

public struct AnimationFrame
{
	public TextureRegion2D Region;
	public float Duration;

	public AnimationFrame(TextureRegion2D region, float duration)
	{
		Region = region;
		Duration = duration;
	}
}
