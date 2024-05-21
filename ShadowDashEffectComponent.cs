using Godot;
using System;
using System.Collections.Generic;

public partial class ShadowDashEffectComponent : Node 
{
    
	[ExportGroup("Shadow dash effects ettings")]

	[Export]
	public Sprite2D sprite;

    [Export]
    public Timer shadow_iterval_timer;
    [Export]
    public float shadow_iterval;

    [Export]
    public Timer shadow_duration_timer;
    [Export]
    public float shadow_duration;
    [Export]
    public Node2D owner;

    private Queue<Sprite2D> shadow_queue = new Queue<Sprite2D>();
    private Sprite2D shadow;

	public override void _Ready(){
        shadow_duration_timer.WaitTime = shadow_duration;
        shadow_iterval_timer.WaitTime = shadow_iterval;

        shadow_iterval_timer.Timeout += OnShadowDashTimerTimeout; 
        shadow_duration_timer.Timeout += OnShadowDurationTimerTimeout;
	}

    private void OnShadowDashTimerTimeout(){
        shadow = (Sprite2D)sprite.Duplicate();
        shadow.TextureFilter = sprite.TextureFilter;
        shadow.GlobalPosition = owner.Position;
        GetTree().CurrentScene.AddChild(shadow);

        shadow_queue.Enqueue(shadow);
        AddChild(shadow);
    }

    private void OnShadowDurationTimerTimeout(){
        shadow_queue.Dequeue().QueueFree();
    }

    public void Start(){
        shadow_iterval_timer.Start();
        shadow_duration_timer.Start();
    }

    public void Stop(){
        shadow_iterval_timer.Stop();
        shadow_duration_timer.Stop();
        while (shadow_queue.Count > 0){
            shadow_queue.Dequeue().QueueFree();
        }
    }

}
