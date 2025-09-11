using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameBase;

public class MouseManager
{
	private MouseState _prev;
	private MouseState _curr;
	public Camera2D Camera;

	public Vector2 CursorPosition => _curr.Position.ToVector2();
	public Rectangle CursorBounds => new Rectangle((int)GlobalCursorPosition.X, (int)GlobalCursorPosition.Y, 1, 1);

	public int MouseWheelValue => _curr.ScrollWheelValue / 7;

	public Vector2 GlobalCursorPosition
	{
		get 
		{
			if(Camera == null) return CursorPosition;
			else return Vector2.Transform(_curr.Position.ToVector2(), Matrix.Invert(Camera.Matrix));
		}
	}

	public bool MouseWheelValueChanged()
	{
		return _curr.ScrollWheelValue != _prev.ScrollWheelValue;
	}

	public bool CursorPositionChanged()
	{
		return _curr.Position != _prev.Position;
	}

	public bool CursorGlobalPositionChanged()
	{
		Vector2 prev = (Camera == null) ? _prev.Position.ToVector2() : Vector2.Transform(_prev.Position.ToVector2(), Matrix.Invert(Camera.Matrix));
		Vector2 curr = GlobalCursorPosition;

		return prev != curr;
	}

	public MouseManager()
	{
		_prev = Mouse.GetState();
		_curr = Mouse.GetState();
	}

	public void Update()
	{
		_prev = _curr;
		_curr = Mouse.GetState();
	}

	public bool IsButtonDown(byte button)
	{
		switch(button)
		{
			case 0: return _curr.LeftButton == ButtonState.Pressed;
			case 1: return _curr.RightButton == ButtonState.Pressed;
			case 2: return _curr.MiddleButton == ButtonState.Pressed;
			default: throw new NotImplementedException();
		}
	}

	public bool IsButtonUp(byte button)
	{
		switch(button)
		{
			case 0: return _curr.LeftButton == ButtonState.Released;
			case 1: return _curr.RightButton == ButtonState.Released;
			case 2: return _curr.MiddleButton == ButtonState.Released;
			default: throw new NotImplementedException();
		}
	}

	public bool WasButtonPressed(byte button)
	{
		switch(button)
		{
			case 0: return _curr.LeftButton == ButtonState.Pressed && _prev.LeftButton == ButtonState.Released;
			case 1: return _curr.RightButton == ButtonState.Pressed && _prev.RightButton == ButtonState.Released;
			case 2: return _curr.MiddleButton == ButtonState.Pressed && _prev.MiddleButton == ButtonState.Released;
			default: throw new NotImplementedException();
		}
	}

	public bool WasButtonReleased(byte button)
	{
		switch(button)
		{
			case 0: return _curr.LeftButton == ButtonState.Released && _prev.LeftButton == ButtonState.Pressed;
			case 1: return _curr.RightButton == ButtonState.Released && _prev.RightButton == ButtonState.Pressed;
			case 2: return _curr.MiddleButton == ButtonState.Released && _prev.MiddleButton == ButtonState.Pressed;
			default: throw new NotImplementedException();
		}
	}
}
