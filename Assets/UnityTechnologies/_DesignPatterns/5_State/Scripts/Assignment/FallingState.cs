using DesignPatterns.StatePattern;
using UnityEngine;

public class FallingState : IState {
	public Color MeshColor { get; set; } = Color.aquamarine;
	
	private PlayerController _playerController;
	
	public FallingState(PlayerController playerController) {
		_playerController = playerController;
	}


	public void Execute() {
		if (_playerController.IsGrounded) {
			_playerController.PlayerStateMachine.TransitionTo(_playerController.PlayerStateMachine.idleState);
		} 
	}

	public void Exit()
	{
		// code that runs when we exit the state
	}
}