using Godot;
using System;

public partial class HurtBoxComponent : Area2D{   

	[Signal]
	public delegate void DamageSignalEventHandler();

	public void Damage(int amount){
		EmitSignal("DamageSignal");
	}
}
