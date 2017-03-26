using UnityEngine;
using System.Collections;

public class Player_White : MonoBehaviour
{

    public PlayerController player;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        //If object is tagged "obs" and split cube collides, SplitCube is destroyed.
        if (other.gameObject.tag == "Obs")
        {
            player.Die();
        }

        if (other.gameObject.tag == "Gem")
        {
            player.Score(other.gameObject);
        }
    }
}
