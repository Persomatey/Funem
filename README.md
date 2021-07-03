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
- <b>Special Thanks</b>
	- [Gerardo Bonnet](https://thethrillofmurder.github.io/Website-Gerardo/gerardo.html)
	- [Mark Brown](https://www.youtube.com/c/MarkBrownGMT/)

</blockquote>
</details>

<details>
<summary>Change List</summary>
<blockquote>

<details>
<summary>CL-000008 (The Fixing Enemies Update)</summary>
<blockquote>

- Made the following changes: 
	- Completely redid the way that the enemy awareness works 
		- No longer based on triggers, it now works by raycasting the distance to the players 
		- Objects tagged as a "Wall" block that raycast early 
	- Made it so that each level controller sets the starting position of the players 
		- There was a weird bug where the player would sometimes spawn in different locations based on the last input from the previous level 
	- Speed up the fade in/out transition time 
		- Edited the animations themselves in the Animations folder 
		- Also made a private float in the Buttons.cs script called fadeTime which will control the acctual waiting for the animaiton to finish 
	- Lowered the minimum wait time in between levels 
		- This is now a private float in the Buttons.cs script called minTimeInLoading 
	- Edited the README to reflect the above changes 

</blockquote>
</details>

<details>
<summary>CL-000007 (The Loading Screen Update)</summary>
<blockquote>

- Made the following changes: 
	- Fixed the way that the outlines for the ttle screen and credits screen worked 
		- They look better now, no weird gaps 
		- Reduced the distance to 3x3 then added another outline to the obj with a distance of 1x1 
	- Added a loading screen for loading in between scenes 
		- It displays the following: 
			- A random tip, trivia, or lore 
			- A loading icon that is dependant on the aforementioned text 
			- The text "Loading..." 
			- It stays on screen for a minimum of 1 second before an option to "continue" appears 
			- When the player presses the spacebar to continue, the scene loads 
		- Added screen transitions 
	- Edited the README to reflect the above changes 

</blockquote>
</details>

<details>
<summary>CL-000006 (The Credits Update)</summary>
<blockquote>

- Made the following changes: 
	- Added a credits menu 
	- Changed the way that the menus work slightly 
	- Added SFX to every button in the game 
	- Added a Pause SFX 
	- Added SFX for when you win a level 
	- Made the postprocessing work in the canvases too 
	- Edited the README to reflect the above changes 

</blockquote>
</details>

<details>
<summary>CL-000005 (The Post Processing Update)</summary>
<blockquote>

- Made the following changes: 
	- Changed the Update() method in the PlayerController.cs script to FixedUpdate() as it now involves movement 
	- Added some post processing 
	- Edited the README to reflect the above changes 

</blockquote>
</details>

<details>
<summary>CL-000004 (The Item Swap Update)</summary>
<blockquote>

- Made the following changes: 
	- Added an item swap animation 
		- Looks adorable 
	- Edited the README to reflect the above changes 

</blockquote>
</details>

<details>
<summary>CL-000003 (The Pickup Update)</summary>
<blockquote>

- Made the following changes: 
	- Fixed bug where the text for an item still appears on screen even after the item has been picked up 
		- Did this by completely redoing the way that the text works 
			- Now I'm using instantiated 3DText objects 
	- Fixed bug where the fadeout animation still occurs even if the item has already been picked up 
		- Fixed this using the above method 
	- Edited the README to reflect the above changes 

</blockquote>
</details>

<details>
<summary>CL-000002 (The AI Update)</summary>
<blockquote>

- Made the following changes: 
	- Made it so that the sprite of the rope changes depending on which side Wasd is compared to Arro
	- Made changes to the enemy AI 
		- If a character leaves the area but the other character is still in the area, the rat will start chasing the other character 
		- Made it so that the sprite flips depending on the position of the character it is chasing 
	- Edited the README to reflect the above changes 

</blockquote>
</details>

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
