using UnityEngine;
using System.Collections;

public class PlayerPawn : APawn {

    public StealthComponent stealth;        

	// Use this for initialization
	protected override void Start ()
    {
        stealth = GetComponent<StealthComponent>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
