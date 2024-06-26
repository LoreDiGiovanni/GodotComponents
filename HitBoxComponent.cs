using Godot;
using System;

public partial class HitBoxComponent : Area2D
{
	public CollisionShape2D box;

    
	[ExportGroup("HitBox settings")]
	[Export]
	public float DamageAmount = 0f;

    [Export]
    public float Knockback = 0;

	public override void _Ready(){
		AreaEntered += OnAreaEntered;
	}

	private void OnAreaEntered(Area2D area){
        var hurt_box = (HurtBoxComponent)area;
        if (hurt_box!= null){
            Vector2 contactPoint = (GlobalPosition + area.GlobalPosition) / 2;
            Vector2 dir= (GlobalPosition- contactPoint).Normalized();
			hurt_box.Damage(DamageAmount, Knockback, -dir);
		}
	}
}

	

