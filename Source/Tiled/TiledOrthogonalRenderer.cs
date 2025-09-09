using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBase.Tiled;

public class TiledOrthogonalRenderer : ITiledRenderer 
{
	public void DrawMap(TiledMap map, Matrix transformMatrix, Rectangle drawBounds)
	{
		if(map.Orientation != "orthogonal") throw new Exception("TiledOrthogonalRenderer need to be a orthogonal orientation");

		foreach(TiledLayer layer in map.Layers)
		{
			if(layer.Visible == false) continue;

			DrawLayer(map, layer, transformMatrix, drawBounds);
		}
	}

	public void DrawLayer(TiledMap map, TiledLayer layer, Matrix transformMatrix, Rectangle drawBounds)
	{
		//Load Tileset
		TiledTileset tileset = map.Tilesets[layer.Id-1];
		if(tileset == null) throw new NullReferenceException($"TiledTilset from TiledLayer {layer.Name} is null: id: {layer.Id}");

		TextureAtlas2D atlas = tileset.Atlas;
		Texture2D texture = atlas.Texture;


		//Draw Tiles
		Base.SpriteBatch.Begin(transformMatrix: transformMatrix);

		for(int y=0; y<layer.Height; y++)
		{
			for(int x=0; x<layer.Width; x++)
			{
				int index = layer.Data[x + y * layer.Width];
				if(index == 0) continue;

				Vector2 pos = new Vector2((map.TileWidth * x), (map.TileHeight * y));
				Color color = Color.White * layer.Opacity;

				Rectangle tile = atlas[index-1].SourceRectangle;
				tile.X = (int)pos.X;
				tile.Y = (int)pos.Y;

				if(drawBounds.Intersects(tile)) Base.SpriteBatch.Draw(texture, pos, atlas[index-1].SourceRectangle, color);
			}
		}

		Base.SpriteBatch.End();
	}
}
