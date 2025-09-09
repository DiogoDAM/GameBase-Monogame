using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBase;

public sealed class RenderComponent : Component 
{
	public TextureRegion2D Region;
	public Vector2 Origin;
	public Vector2 Offset;
	public Color Color = Color.White;
	public SpriteEffects Flip;
	public float Depth;

	public RenderComponent(Entity e) : base(e)
	{
	}

	public void LoadTextureRegion2D(TextureRegion2D region)
	{
		Region = region;
	}

	public void LoadTextureRegion2D(Texture2D texture, int x, int y, int w, int h)
	{
		Region = new(texture, x, y, w, h);
	}

    public override void Start()
    {
    }

    public override void Update(Time time)
    {
    }

    public override void Draw()
    {
		Region.Draw(Entity.Transform.Position + Offset, Color, Entity.Transform.Rotation, Origin, Entity.Transform.Scale, Flip, Depth);
    }

}
