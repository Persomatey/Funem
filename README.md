# Funem
<i>A top down adventure game for the GMTK 2021 Game Jam themed "Joined Together"</i>

https://itch.io/jam/gmtk-2021

<img src="https://img.itch.zone/aW1nLzYyMDc3OTgucG5n/original/aOHUkp.png" width="347" height="347" />

## Details 

<details>
<summary>Summary</summary>
<blockquote>
	
A top down twin stick puzzle game, inspired by 2D Zelda and Final Fantasy Adventure. </i> 

<i>The game has bee sumitted to itch.io and the game jam 4 hours, 25 minutes before the deadline </i>

<i>Link to the itch.io page: https://persomatey.itch.io/funem </i>

<i>Link to the game jam submission page: https://itch.io/jam/gmtk-2021/rate/1082906 </i>

</blockquote>
</details> 

<details>
<summary>Specs</summary>
<blockquote>
	
Unity 2020.3.8f1
https://download.unity3d.com/download_unity/507919d4fff5/UnityDownloadAssistant-2020.3.8f1.exe

SLN solution in Visual Studio Community 2019 Preview 
https://visualstudio.microsoft.com/vs/community/

Trello board
https://trello.com/b/TFLqyVVL/project-tethered
	
</blockquote>
</details> 

<details>
<summary>Credits</summary>
<blockquote>
	
- <b>Programming</b>
	- [Hunter Goodin](https://huntergoodin.com/)
- <b>Art</b>
	- [Hunter Goodin](https://huntergoodin.com/)
	- [Kenny Assets](https://www.kenney.nl/assets)
- <b>SFX</b>
	- [Hunter Goodin](https://huntergoodin.com/)

</blockquote>
</details>

<details>
<summary>Change List</summary>
<blockquote>

<details>
<summary>CL-000001 (The Combat Update)</summary>
<blockquote>

- Made the following changes: 
	- Made some changes to the combat: 
		- Made sword swing faster 
			- Speed was 1000 now it's 1500 
		- Made sword swing either clockwise or counterclockwise depending on the last direction that character moved 
			- Different depenging on whether it's Wasd or Arro 
		- Made it so that both characters can swing their swords at the same time 
	- Made some bug fixes: 
		- Fixed bug where the enemy can still damage the player even if they're dead 
			- Fixed this by checkinging if the death coroutine has started before dealing the damage 
		- Fixed bug where dead enemies can be hit through walls 
			- My previous fix for the aforementioned bug was to remove the collision which is what caused this bug 
				- The fix for that bug also fixed this bug 
		- Fixed bug where sometimes swinging the sword would make the enemies go flying way too far 
			- This was caused by having the coroutine that stopped velocity in the sword's script so this coroutine would not conclude if the sword was destroyed before the timer was up 
			- Fixed this by putting the coroutine in the enemy's script instead 
	- Edited the README to reflect the above changes 


</blockquote>
</details>

<details>
<summary>CL-000000 (The First Update)</summary>
<blockquote>

- Made the following changes: 
	- Added Unity project as it was when submitted 
	- Added .gitignore file 
	- Edited the README to reflect the above changes 

</blockquote>
</details>

</blockquote>
</details>
