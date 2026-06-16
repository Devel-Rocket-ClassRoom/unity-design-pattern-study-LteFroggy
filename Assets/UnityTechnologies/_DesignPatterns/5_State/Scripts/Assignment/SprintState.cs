using System.Collections;
using DesignPatterns.StatePattern;
using UnityEngine;

public class SprintState : IState {
	public Color MeshColor { get; set; } = Color.yellow;
	
	private readonly PlayerController _player;
	
	public SprintState(PlayerController player) {
		_player = player;
	}

	public void Enter() {
		
	}
	public void Execute() {
		if (!_player.IsGrounded)
		{
			_player.PlayerStateMachine.TransitionTo(_player.PlayerStateMachine.jumpState);
		}
            
		if (!_player.IsSprinting) {
			_player.PlayerStateMachine.TransitionTo(_player.PlayerStateMachine.walkState);
		}
		
		// 여기서도 일정 속도 이하가 되면 바로 idle로 돌려보내기.
		if (Mathf.Abs(_player.CharController.velocity.x) < 0.1f && Mathf.Abs(_player.CharController.velocity.z) < 0.1f)
		{
			_player.PlayerStateMachine.TransitionTo(_player.PlayerStateMachine.idleState);
		}
	}
	
	public void Exit() {
		
	}
}