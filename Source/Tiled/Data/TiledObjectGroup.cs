using System.Collections.Generic;

namespace GameBase.Tiled;

public class TiledObjectGroup
{
	public string Name { get; set; }
	public List<TiledObject> Objects { get; set; }

	public TiledObjectGroup()
	{
		Objects = new List<TiledObject>();
	}
}
