using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace GameBase;

public class TextureAtlas2D
{
	private Dictionary<object, TextureRegion2D> _regions;

	public Texture2D Texture { get; set; }
	public Rectangle SourceRectangle { get { return Texture.Bounds; } }

	public TextureRegion2D this[object index] 
	{
		get 
		{
			if(!_regions.ContainsKey(index)) throw new KeyNotFoundException("index doesn't exist  in TextureAtlas");

			return _regions[index];
		}
	}

	public TextureAtlas2D(Texture2D texture)
	{
		Texture = texture;
		_regions = new();
	}

	public TextureAtlas2D(Texture2D texture, int tileWidth, int tileHeight)
	{
		_regions = new();
		Texture = texture;

		int cols = texture.Width / tileWidth;
		int rows = texture.Height / tileHeight;

		for(int row=0; row<rows; row++)
		{
			for(int col=0; col<cols; col++)
			{
				int index = col + row * cols;
				_regions.Add(index, new(Texture, col * tileWidth, row * tileHeight, tileWidth, tileHeight));
			}
		}
	}

	public void AddRegion(object name, int x, int y, int w, int h)
	{
		_regions.Add(name, new(Texture, x, y, w, h));
	}

	public TextureRegion2D GetRegion(object name)
	{
		if(!_regions.ContainsKey(name)) throw new KeyNotFoundException();

		return _regions[name];
	}

	public static TextureAtlas2D CreateFromFile(ContentManager content, string filename)
	{
		TextureAtlas2D atlas;

		string filepath = Path.Combine(content.RootDirectory, filename);

		XDocument doc = XDocument.Load(filepath);
		XElement root = doc.Root;

		string texturePath = root.Element("Texture").Value;
		atlas = new(content.Load<Texture2D>(texturePath));

		var regions = root.Element("Regions").Elements("Region");

		if(regions != null)
		{
			foreach(var region in regions)
			{
				atlas.AddRegion(
						region.Attribute("name").Value,
						int.Parse(region.Attribute("x")?.Value ?? "0"),
						int.Parse(region.Attribute("y")? .Value ?? "0"),
						int.Parse(region.Attribute("width")?.Value ?? "0"),
						int.Parse(region.Attribute("height")?.Value ?? "0")
						);
			}
		}

		return atlas;
	}
}
