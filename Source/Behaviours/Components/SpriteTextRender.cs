using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBase;

public sealed class SpriteTextRender : Component 
{
	public TextureFont Font;
	public Vector2 Origin;
	public Vector2 Offset;
	public Color Color = Color.White;
	public SpriteEffects Flip;
	public float Depth;

	public SpriteTextRender() : base()
	{
	}

	public SpriteTextRender(Entity e) : base(e)
	{
	}

	public void LoadTextureFont(TextureFont font)
	{
		Font = font;
	}

	public void LoadTextureFont(SpriteFont font, string text)
	{
		Font = new(font, text);
	}

    public override void Start()
    {
    }

    public override void Update(Time time)
    {
    }

    public override void Draw()
    {
		Font.DrawString(Entity.Transform.Position + Offset, Color, Entity.Transform.Rotation, Origin, Entity.Transform.Scale, Flip, Depth);
    }

}
