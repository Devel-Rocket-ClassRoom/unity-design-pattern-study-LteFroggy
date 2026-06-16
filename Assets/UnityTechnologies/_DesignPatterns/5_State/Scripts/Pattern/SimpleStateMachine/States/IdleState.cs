using UnityEngine;

namespace DesignPatterns.StatePattern
{
    public class IdleState : IState
    {
        private PlayerController player;

        // color to change player (alternately: pass in color value with constructor)
        Color meshColor = Color.white;
        public Color MeshColor { get => meshColor; set => meshColor = value; }

        // pass in any parameters you need in the constructors
        public IdleState(PlayerController player)
        {
            this.player = player;
        }

        public void Enter()
        {
            // code that runs when we first enter the state
            //Debug.Log("Entering Idle State");
        }

        // per-frame logic, include condition to transition to a new state
        public void Execute()
        {
            // if we're no longer grounded, transition to jumping
            if (!player.IsGrounded)
            {
                IState airborneState = player.IsFalling
                    ? player.PlayerStateMachine.fallingState
                    : player.PlayerStateMachine.jumpState;
                player.PlayerStateMachine.TransitionTo(airborneState);
                return;
            }

            // if we move above a minimum threshold, transition to walking
            if (Mathf.Abs(player.CharController.velocity.x) > 0.1f || Mathf.Abs(player.CharController.velocity.z) > 0.1f)
            {
                // 속도가 일정 이상이 되었을 때, 달리는 상태라면 바로 sprintstate로.
                if (player.IsSprinting) {
                    player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.sprintState);    
                }
                // 아니면 그냥 Walking
                else {
                    player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.walkState);
                }

                return;
            }
        }

        public void Exit()
        {
            // code that runs when we exit the state
            //Debug.Log("Exiting Idle State");
        }
    }
}
