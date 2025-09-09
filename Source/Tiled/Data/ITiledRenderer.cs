using Microsoft.Xna.Framework;

namespace GameBase.Tiled;

public interface ITiledRenderer
{
	public void DrawMap(TiledMap map, Matrix transformMatrix, Rectangle drawBounds);

	public void DrawLayer(TiledMap map, TiledLayer layer, Matrix transformMatrix, Rectangle drawBounds);
}
