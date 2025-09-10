using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace GameBase;

public static class Input
{
	public static MouseManager Mouse  = new();
	public static KeyboardManager Keyboard = new();

	private static Dictionary<string, List<InputAction>> _actions = new();

	public static void Update()
	{
		Mouse.Update();
		Keyboard.Update();
	}

	public static void AddAction(string actionName)
	{
		_actions.Add(actionName, new List<InputAction>());
	}

	public static void AddKeyboardAction(string actionName, Keys key)
	{
		if(!_actions.ContainsKey(actionName)) throw new KeyNotFoundException($"The action: {actionName} not implemented");

		_actions[actionName].Add(InputAction.CreateKeyboardAction(key));
	}

	public static void AddMouseAction(string actionName, byte button)
	{
		if(!_actions.ContainsKey(actionName)) throw new KeyNotFoundException($"The action: {actionName} not implemented");

		_actions[actionName].Add(InputAction.CreateMouseAction(button));
	}

	public static List<InputAction> GetAction(string actionName)
	{
		if(!_actions.ContainsKey(actionName)) throw new KeyNotFoundException($"The action: {actionName} not implemented");

		return _actions[actionName];
	}

	public static void LoadFromFile(ContentManager content, string filePath)
	{
		string fullpath = Path.Combine(content.RootDirectory, filePath);

		XmlDocument doc = new();
		doc.Load(fullpath);

		var actionsNodes = doc.SelectSingleNode("Actions");
		foreach(XmlNode action in actionsNodes)
		{
			string name = action.Attributes["name"].Value;
			AddAction(name);

			foreach(XmlNode keynode in action.SelectNodes("Key"))
			{
				if(Enum.TryParse(keynode.InnerText, out Keys key))
				{
					AddKeyboardAction(name, key);
				}
			}

			foreach(XmlNode mouseButtonNode in action.SelectNodes("MouseButton"))
			{
				AddMouseAction(name, byte.Parse(mouseButtonNode.InnerText));
			}
		}
	}

	public static bool IsDown(List<InputAction> actions)
	{
		foreach(var action in actions)
		{
			switch(action.Type)
			{
				case EInputActionType.Keyboard: return Keyboard.IsKeyDown(action.Key);
				case EInputActionType.Mouse: return Mouse.IsButtonDown(action.Button);
			}
		}

		return false;
	}

	public static bool IsUp(List<InputAction> actions)
	{
		foreach(var action in actions)
		{
			switch(action.Type)
			{
				case EInputActionType.Keyboard: return Keyboard.IsKeyUp(action.Key);
				case EInputActionType.Mouse: return Mouse.IsButtonUp(action.Button);
			}
		}

		return false;
	}

	public static bool WasPressed(List<InputAction> actions)
	{
		foreach(var action in actions)
		{
			switch(action.Type)
			{
				case EInputActionType.Keyboard: return Keyboard.WasKeyPressed(action.Key);
				case EInputActionType.Mouse: return Mouse.WasButtonPressed(action.Button);
			}
		}

		return false;
	}

	public static bool WasReleased(List<InputAction> actions)
	{
		foreach(var action in actions)
		{
			switch(action.Type)
			{
				case EInputActionType.Keyboard: return Keyboard.WasKeyReleased(action.Key);
				case EInputActionType.Mouse: return Mouse.WasButtonReleased(action.Button);
			}
		}

		return false;
	}
}
