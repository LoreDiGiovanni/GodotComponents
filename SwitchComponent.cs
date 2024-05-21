using Godot;
using System;

public partial class SwitchComponent : Node{

	[Signal]
	public delegate void ValueChangedEventHandler(bool value);

	[Export]
	public bool InitialValue = false;

	public override void _Ready(){

		
	}

	public bool Switch(){
		InitialValue = !InitialValue;
		EmitSignal("ValueChanged", InitialValue);
		return InitialValue;
	}

	public bool getValue(){
		return InitialValue;
	}

}


