using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// TODO 1: Create a simple class to contain one entry in the blackboard
// should at least contain the gameobject, position, timestamp and a bool
// to know if it is in the past memory

 public class Knowledge
{
    public GameObject target;
    public Vector3 position;
    public float timestamp;
    public bool inMemory;
}

public class AIMemory : MonoBehaviour {

	public GameObject Cube;
	public Text Output;
    AIPerceptionManager perceptionManager;

    // TODO 2: Declare and allocate a dictionary with a string as a key and
    // your previous class as value

    Dictionary<string, Knowledge> playerKnowledge;


    // TODO 3: Capture perception events and add an entry if the player is detected
    // if the player stop from being seen, the entry should be "in the past memory"

    void PerceptionEvent(PerceptionEvent ev)
    {
        if (ev.type == global::PerceptionEvent.types.SEEING)
        {
            if (playerKnowledge.ContainsKey("player"))
            {
                Knowledge aux_player;
                playerKnowledge.TryGetValue("player", out aux_player);
                aux_player.position = ev.go.transform.position;
                playerKnowledge["player"] = aux_player;
                Debug.Log("Updating");

            }
            else
            {
                Knowledge player = new Knowledge();
                player.target = ev.go;
                player.position = ev.go.transform.position;
                player.timestamp = Time.time;
                player.inMemory = false;

                playerKnowledge.Add("player", player);
                Debug.Log("Creating new one");
            }

        }
        else
        {
            Knowledge aux_player;
            playerKnowledge.TryGetValue("player", out aux_player);
            Debug.Log(aux_player.position);
        }
    }

    // Use this for initialization
    void Start () {

        playerKnowledge = new Dictionary<string, Knowledge>();
        perceptionManager = GetComponent<AIPerceptionManager>();

    }

    // Update is called once per frame
    void Update () 
	{
        // TODO 4: Add text output to the bottom-left panel with the information
        // of the elements in the Knowledge base
        Knowledge aux_player=new Knowledge();
        playerKnowledge.TryGetValue("player", out aux_player);

        if(aux_player!=null)
            Cube.transform.position = aux_player.position;

        string result = string.Format("{0},{0},{0}",
            aux_player.position.x,
            aux_player.position.y,
            aux_player.position.z);

        Output.text(result);
    }

}
