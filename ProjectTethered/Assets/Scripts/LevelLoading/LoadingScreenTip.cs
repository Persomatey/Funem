using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenTip : MonoBehaviour
{
	private int rand;

	void Awake()
    {
		string[] tips = new string[17]; 
		tips[0] = "<size=20><b>Tip:</b></size>" + System.Environment.NewLine + "Be mindful of what item you pick up. " + System.Environment.NewLine + "Wasd and Arro can only carry one item each. "; 
		tips[1] = "<size=20><b>Tip:</b></size>" + System.Environment.NewLine + "You can swap items between Wasd and Arro by pressing the Spacebar. ";
		tips[2] = "<size=20><b>Tip:</b></size>" + System.Environment.NewLine + "Keys can only be used once and will break after use. ";
		tips[3] = "<size=20><b>Tip:</b></size>" + System.Environment.NewLine + "An axe can be used as many times as you want and will not break. ";
		tips[4] = "<size=20><b>Tip:</b></size>" + System.Environment.NewLine + "Rats can hurt the player. " + System.Environment.NewLine + "Be careful not to get hit thrice or it will be game over. ";
		tips[5] = "<size=20><b>Tip:</b></size>" + System.Environment.NewLine + "Wasd and Arro share health. An attack dealt to on Wasd also hurts Arro " + System.Environment.NewLine + "(and vice versa). ";
		tips[6] = "<size=20><b>Tip:</b></size>" + System.Environment.NewLine + "If you can't quite reach what you want, picking up rope extends the distance Wasd and Arro can travel apart from one another. ";
		tips[7] = "<size=20><b>Trivia:</b></size>" + System.Environment.NewLine + "Funem is the Latin word for rope. Tethered, Petulans, Relligo, and Roped were also considered as potential names." + System.Environment.NewLine + "Funem was chosen because it has fun right in the name. "; 
		tips[8] = "<size=20><b>Lore:</b></size>" + System.Environment.NewLine + "Wasd and Arro are third counsins who met a week and a half before embarking into this dungeon. ";
		tips[9] = "<size=20><b>Trivia:</b></size>" + System.Environment.NewLine + "Funem was loosely inspired by games such as Final Fantasy Adventure and classic Zelda games. ";
		tips[10] = "<size=20><b>Tip:</b></size>" + System.Environment.NewLine + "Rats have poor attention spans. " + System.Environment.NewLine + "If another person walks into their field of view, they will forget all about the person they were just chasing. ";
		tips[11] = "<size=20><b>Trivia:</b></size>" + System.Environment.NewLine + "Funem was made during the GMTK 2021 Game Jam which had the theme 'Joined Together'. ";
		tips[12] = "<size=20><b>Tip:</b></size>" + System.Environment.NewLine + "Keys can open yellow doors by walking up to them and pressing either Q or Right Shift (depending on the character). ";
		tips[13] = "<size=20><b>Tip:</b></size>" + System.Environment.NewLine + "Axes chop down trees by walking up to the tree and pressing either Q or Right Shift (depending on the character). ";
		tips[14] = "<size=20><b>Tip:</b></size>" + System.Environment.NewLine + "Stepping on pressure plates unlocks certain doors. ";
		tips[15] = "<size=20><b>Lore:</b></size>" + System.Environment.NewLine + "Wasd and Arro both have a tendancy to get lost vary easily. Which is why they tied a rope to one another to stay joined together. It is also why they often end up in different rooms. ";
		tips[16] = "<size=20><b>Tip:</b></size>" + System.Environment.NewLine + "If you equip an item while already having one equipped, the currently equipped item will be dropped on the ground and can be picked up later. ";

		rand = Random.Range(0, tips.Length);

		GameObject.Find("LoadingImg").GetComponent<LoadingScreenSpin>().SetSprite(rand); 

		GetComponent<Text>().text = tips[rand];
	}
}
