using Godot;
using System;

public partial class ActivableComponent : Node{

	[ExportGroup("Activate settings")]
	[Export]
	public SwitchComponent switch_component;
	[Export]
	public Node target;

	public override void _Ready(){
		if (switch_component != null) {
			switch_component.ValueChanged+= Activate;
		}else{
			GD.Print("No switch component provided");
		}
	}

	public void Activate(bool value){
		if (target == null){
			GD.Print("No target provided");
		}
		target.Call("Activate",value); 
	}

}
