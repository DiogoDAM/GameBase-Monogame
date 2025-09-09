using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;

namespace GameBase;

public class Base : Game
{
	private static Base s_instance;
	public static Base Instance => s_instance;

	public static new GraphicsDevice GraphicsDevice { get; private set; }
	public static GraphicsDeviceManager Graphics { get; private set; }
	public static new ContentManager Content { get; private set; }
	public static SpriteBatch SpriteBatch { get; private set; }

	public static string GameTitle { get; private set; }
	public static int WindowWidth => Graphics.PreferredBackBufferWidth;
	public static int WindowHeight => Graphics.PreferredBackBufferHeight;
	public static Time Time;

	public static int GridSize = 16;
	public static Vector2 DefaultScale = Vector2.One;

	public static bool IsDebugMode { get; protected set; }

	public Base(string windowTitle, int ww, int wh, bool isfullscreen, bool isdebug=true)
	{
		s_instance = this;

		Graphics = new GraphicsDeviceManager(this);

		Content = base.Content;
		Content.RootDirectory = "Content";

		GameTitle = windowTitle;
		Window.Title = GameTitle;

		SetWindowSize(ww, wh);
		SetWindowFullscreen(isfullscreen);

		IsMouseVisible = true;

		IsDebugMode = isdebug;
	}

	protected override void Initialize()
	{
		GraphicsDevice = base.GraphicsDevice;
		Drawer.Initialize(GraphicsDevice);

		SpriteBatch = new SpriteBatch(GraphicsDevice);

		base.Initialize();
	}

	protected override void Update(GameTime gameTime)
	{
		Time.DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

		base.Update(gameTime);
	}

	protected void ActiveDebugMode()
	{
		IsDebugMode = true;
		
		Window.Title = $"{GameTitle} -- {GC.GetTotalMemory(true)/1024} Kb";
	}

	protected override void Draw(GameTime gameTime)
	{
		base.Draw(gameTime);
	}

	public void SetWindowSize(int ww, int wh)
	{
		Graphics.PreferredBackBufferWidth = ww;
		Graphics.PreferredBackBufferHeight = wh;
		Graphics.ApplyChanges();
	}

	public void SetWindowFullscreen(bool isfullscreen)
	{
		Graphics.IsFullScreen = isfullscreen;
		Graphics.ApplyChanges();
	}

}
