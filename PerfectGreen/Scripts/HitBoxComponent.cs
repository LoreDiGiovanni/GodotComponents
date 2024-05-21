using Godot;
using System;

public partial class HitBoxComponent : Area2D
{
	public CollisionShape2D box;

    
	[ExportGroup("HitBoxsettings")]
	[Export]
	public int DamageAmount = 10;

    [Export]
    public int Knockback = 0;

	public override void _Ready(){
		AreaEntered += OnAreaEntered;
	}

	private void OnAreaEntered(Area2D area){
        var hurt_box = (HurtBoxComponent)area;
        if (hurt_box!= null){
			hurt_box.Damage(DamageAmount);
		}
	}
}

	

