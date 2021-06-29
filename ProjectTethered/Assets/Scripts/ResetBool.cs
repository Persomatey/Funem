using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBool : StateMachineBehaviour
{
	public bool resetEnterFadeOutNow;
	public bool resetExitNow; 

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if(resetEnterFadeOutNow) animator.SetBool("EnterFadeOut", false);
		if(resetExitNow) animator.SetBool("ExitNow", false);
	}
}
