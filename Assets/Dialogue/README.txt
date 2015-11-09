1. Create folder with the NPC's name inside the Dialogue folder
    *This will be where all the dialogue for that NPC is stored
2. Create the dialogue as a .txt file
	a. Each line of the .txt file represents a new page of dialogue for the NPC
	b. Each .txt file should represent a different state for the NPC, e. g., before
	   and after completeing a quest
	c. Player choices/responses should be there own separate file, e. g., a player
	   response file would contain all choices the player has for a set NPC dialogue
	   state
	d. Make sure NPC dialogue and player responses work parallel to one another, e. g.,
	   if a player's responses are Yes, No, Maybe, then the first line of the NPC should
	   be in response to Yes, the second to No, and the third to Maybe
3. Quests are done inside the code, so if there is dialogue for a specific quest, it may
   be helpful to label it as such
4. Try to make the names of different dialogue texts that connect be similar, e. g., if
   the player has to respond to the NPC's first set of dialogue, it may be helpful to
   name the text files NPCNameDialogue1 and NPCNameResponse1
5. Use the NPCName folder for any needed examples