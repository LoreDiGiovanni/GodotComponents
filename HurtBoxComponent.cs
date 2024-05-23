using Godot;
using System;

public partial class HurtBoxComponent : Area2D{   

	[Signal]
	public delegate void DamageSignalEventHandler(float amount, float knockback, Vector2 dir);

	public void Damage(float amount, float knockback,Vector2 dir){
		EmitSignal("DamageSignal", amount, knockback, dir);
	}
}
