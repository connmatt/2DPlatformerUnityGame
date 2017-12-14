using UnityEngine;
using System.Collections;

public class PatrolState : IEnemyState
{
	public void Enter(Enemy enemy)
	{
	
	}

	public void Execute()
	{
		
	}
	
	public void Exit()
	{
	
	}
	
	public void OnTriggerEnter(Collider2D other)
	{
	
	}
	
	private void Patrol()
	{
		/*patrolTimer += Time.deltaTime;
		
		if(patrolTimer >= patrolDuration)
		{
			Enemy.ChangeState(newIdleState());
		}*/
	}
	

}

