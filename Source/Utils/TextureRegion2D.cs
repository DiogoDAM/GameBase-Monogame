using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBase;

public sealed class TextureRegion2D
{
	public Texture2D Texture;

	public Rectangle SourceRectangle => new Rectangle(X, Y, Width, Height);

	public int X;
	public int Y;
	public int Width;
	public int Height;

	public TextureRegion2D() { }

	public TextureRegion2D(Texture2D texture, int x, int y, int w, int h)
	{
		Texture = texture;
		X = x;
		Y = y;
		Width = w;
		Height = h;
	}

	public TextureRegion2D(Texture2D texture, Rectangle bounds)
	{
		Texture = texture;
		X = bounds.X;
		Y = bounds.Y;
		Width = bounds.Width;
		Height = bounds.Height;
	}

	public void Draw(Vector2 pos, Color color)
	{
		Core.SpriteBatch.Draw(Texture, pos, SourceRectangle, color);
	}

	public void Draw(Vector2 pos, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects flip, float depth)
	{
		Core.SpriteBatch.Draw(Texture, pos, SourceRectangle, color, rotation, origin, scale, flip, depth);
	}

	public override string ToString() => $"(Texture2D: {Texture}, SourceRectangle: {SourceRectangle})";
}
