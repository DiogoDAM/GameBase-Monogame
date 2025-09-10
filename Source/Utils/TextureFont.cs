using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBase;

public sealed class TextureFont
{
	public SpriteFont Font;
	public string Text;

	public Vector2 Size() => Font.MeasureString(Text);

	public TextureFont()
	{
	}

	public TextureFont(SpriteFont font, string text)
	{
		Font = font;
		Text = text;
	}

	public void DrawString(Vector2 pos, Color color)
	{
		Core.SpriteBatch.DrawString(Font, Text, pos, color);
	}

	public void DrawString(Vector2 pos, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects flip, float depth)
	{
		Core.SpriteBatch.DrawString(Font, Text, pos, color, rotation, origin, scale, flip, depth);
	}
}
