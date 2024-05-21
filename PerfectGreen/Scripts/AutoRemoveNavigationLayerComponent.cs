
using Godot;
using System;

// This script is for the tilemap. It isn't a real component.
// It simply removes the navigation layer from the tilemap.
// If you don't have a script on the tilemap, you can just add this one.
// If you already have a script, you will need to manually merge it.
public partial class AutoRemoveNavigationLayerComponent : TileMap {
    public override void _Ready(){
        _use_tile_data_runtime_update(0, Vector2i.Zero);
    }

    public override virtual bool _use_tile_data_runtime_update ( int layer, Vector2i coords){

        
    }

}
