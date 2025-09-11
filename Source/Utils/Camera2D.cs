using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBase;

public sealed class Camera2D
{
	public Vector2 Position { get; set; }
	public float Rotation { get; set; }
	public Vector2 Scale { get; set; } = Core.DefaultScale;

	public Vector2 Offset;

	public Viewport Viewport;

	public Rectangle BoundingRectangle => new Rectangle((int)Position.X, (int)Position.Y, (int)(Viewport.Width * Scale.X), (int)(Viewport.Height * Scale.Y));

	public Matrix Matrix 
	{
		get {
			return Matrix.CreateTranslation(-Position.X - Offset.X, -Position.Y - Offset.Y, 0)
				* Matrix.CreateRotationZ(Rotation)
				* Matrix.CreateScale(Scale.X, Scale.Y, 1f);
		}
	}

	public Camera2D()
	{
		Viewport = new();
		Viewport.Width = Core.WindowWidth;
		Viewport.Height = Core.WindowHeight;
	}

	public Camera2D(int w, int h)
	{
		Viewport = new();
		Viewport.Width = w;
		Viewport.Height = h;
	}

	public Camera2D(Vector2 pos, int w, int h)
	{
		Position = pos;
		Viewport = new();
		Viewport.Width = w;
		Viewport.Height = h;
	}

	public Camera2D(Vector2 pos, float rot, Vector2 scale, int w, int h)
	{
		Position = pos;
		Rotation = rot;
		Scale = scale;

		Viewport = new();
		Viewport.Width = w;
		Viewport.Height = h;
	}

	public void Goto(Vector2 pos)
	{
		Position = pos;
	}

	public void Move(Vector2 moveValue)
	{
		Position += moveValue;
	}

	public void ZoomIn(Vector2 zoom)
	{
		Scale += zoom;
	}

	public void ZoomOut(Vector2 zoom)
	{
		Scale -= zoom;
	}

	public void Rotate(float rotation)
	{
		Rotation += rotation;
	}
}
