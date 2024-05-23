using Godot;
using System;

public partial class HealtComponent : Node
{

	
	[ExportGroup("Healt component settings")]

	[Export]
	public float max_healt = 100f;

	public bool damagable = true;
	public float healt= 0f;

	public override void _Ready(){
		healt = max_healt;
	}

	public void Damage(float amount){
		healt -= amount;
	}

	public void Healing(float amount){
		var tmp_healt = amount + healt;
		if (tmp_healt> max_healt){
			healt = max_healt;
		}else{
			healt = tmp_healt;
		}
	}

	public float GetHealt(){
		return healt;
	}

	public bool IsDead(){
		return healt <= 0f;
	}

}

	

