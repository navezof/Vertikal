using UnityEngine;
using System.Collections;

public class APawn : MonoBehaviour {

    public MoveComponent move;

    // Use this for initialization
    protected virtual void Start ()
    {
        move = GetComponent<MoveComponent>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
