using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenSpin : MonoBehaviour
{
	private float spinSpeed;

	public Sprite[] sprites; // 0 = Sword , 1 = Axe , 2 = Key , 3 = Tree , 4 = Rope , 5 = Door , 6 = Heart 

	void Awake()
    {
		spinSpeed = 45; 
    }

    void FixedUpdate()
    {
		transform.Rotate(0, 0, Time.deltaTime * -spinSpeed);
	}

	public void SetSprite(int tipIndex)
	{
		// 0 = Sword , 1 = Axe , 2 = Key , 3 = Tree , 4 = Rope , 5 = Door , 6 = Heart 

		switch (tipIndex)
		{
			case 1:
				GetComponent<Image>().sprite = sprites[1];
				break;
			case 2: 
				GetComponent<Image>().sprite = sprites[2];
				break;
			case 3:
				GetComponent<Image>().sprite = sprites[1];
				break;
			case 4:
				GetComponent<Image>().sprite = sprites[0];
				break;
			case 5:
				GetComponent<Image>().sprite = sprites[6];
				break;
			case 6:
				GetComponent<Image>().sprite = sprites[4];
				break;
			case 7:
				GetComponent<Image>().sprite = sprites[4];
				break;
			case 10:
				GetComponent<Image>().sprite = sprites[0];
				break;
			case 12:
				GetComponent<Image>().sprite = sprites[2];
				break;
			case 13:
				GetComponent<Image>().sprite = sprites[3];
				break;
			case 14:
				GetComponent<Image>().sprite = sprites[5];
				break;
			case 15:
				GetComponent<Image>().sprite = sprites[4];
				break;
			case 16:
				GetComponent<Image>().sprite = sprites[1];
				break;
			default:
				int randNum = Random.Range(0, sprites.Length);
				GetComponent<Image>().sprite = sprites[randNum];
				break; 
		}
	}
}
