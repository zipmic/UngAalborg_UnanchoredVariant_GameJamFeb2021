using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Sørger for at man kan spawne en spiller til
/// controller id når man trykker på en knap.
/// Dog skal man kun have mulighed for at gøre dette
/// en enkelt gang. 
/// </summary>
public class PlayerControllerAssignmentManager : MonoBehaviour
{

	public GameObject PrefabPlayer;



	private void Update()
	{
		
	}






	//	private bool[] _playerAssigned = new bool[4];


	/* // Update is called once per frame
	  void Update()
	  {
		  for (int i = 0; i < 4; i++)
		  {
			  if (!_playerAssigned[i])
			  {
				  CheckForPlayer(i);
			  }
		  }

		  print("Joystick count: " + ReInput.controllers.joystickCount);

		  for (int i = 0; i < ReInput.controllers.joystickCount; i++)
		  {
			  print("iterating...");

			  //print(ReInput.controllers.GetAnyButton());
			  //ReInput.controllers.

			  if (ReInput.players.GetPlayer(i).GetAnyButtonDown())
			  {
				  print("Got the press");

				  if (ReInput.players.GetPlayer(i).controllers.joystickCount <= 0)
				  {
					  ReInput.players.GetPlayer(i).controllers.AddController<Controller>(i, true);
					  print("Assigned joystick to player " + i);
					  SpawnPlayerAndAssignID(i);
				  }
			  }
		  }






	  }

	  void SpawnPlayerAndAssignID(int id)
	  {
		  GameObject tmp = Instantiate(PrefabPlayer) as GameObject;
		  tmp.transform.position = new Vector3(-4 + (1 * id), 0, 0);
		  tmp.GetComponent<PlayerScript>().SetPlayerID(id);
	  }

	  void CheckForPlayer(int playerID)
	  {
		  Player player = ReInput.players.GetPlayer(playerID);

		  if (player.GetAnyButtonDown())
		  {
			  _playerAssigned[playerID] = true;
			  print(playerID + " is set to true");

			  GameObject tmp = Instantiate(PrefabPlayer) as GameObject;
			  tmp.transform.position = new Vector3(-4 + (1 * playerID), 0, 0);
			  tmp.GetComponent<PlayerScript>().SetPlayerID(playerID);

		  }

	  }

  */
}
