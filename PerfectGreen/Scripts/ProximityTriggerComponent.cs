using Godot;
using System;

public partial class ProximityTriggerComponent : Area2D{

    [Signal]
    public delegate void TriggeredEventHandler(Node2D body);

    public override void _Ready(){
        BodyEntered += OnBodyEntered;
    }

    private void OnBodyEntered(Node2D body){
        EmitSignal("Triggered", body);
    }
}	
