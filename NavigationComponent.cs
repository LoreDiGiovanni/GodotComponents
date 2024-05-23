using Godot;
using System;

public partial class NavigationComponent : Node2D{

	[ExportGroup("Navigation settings")]

	[Export]
	public NavigationAgent2D navigation_agent;

	[Export]
	public Timer timer; 

	[Export]
	public ProximityTriggerComponent proximity_trigger_component;

	[Export]
	public VelocityComponent velocity_component;
	
	[Export]
	public CharacterBody2D Bat;


	private Node2D body; 
	private Vector2 direction;

	public override void _Ready(){
		timer.Autostart = true;
		timer.WaitTime = 0.1f;
		navigation_agent.PathDesiredDistance = 4;
		navigation_agent.TargetDesiredDistance = 4;
		//navigation_agent.PathPostprocessing = NavigationAgent2D.;
		proximity_trigger_component.Triggered += OnTriggered;
		timer.Timeout += OnTimerTimeout;
	}

	public override void _PhysicsProcess(double delta){
		if (body != null) {
			direction = Bat.GlobalPosition.DirectionTo(navigation_agent.GetNextPathPosition());
			velocity_component.MoveOnGroundByDirection(direction);
			velocity_component.Move();
		}
		
	}

	private void OnTriggered(Node2D body){
		this.body = body;
		navigation_agent.TargetPosition = body.GlobalPosition; 
	}

	private void OnTimerTimeout(){
		navigation_agent.TargetPosition = body.GlobalPosition; 
	}

}
