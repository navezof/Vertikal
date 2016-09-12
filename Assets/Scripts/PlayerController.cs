using UnityEngine;
using System.Collections;

public class PlayerController : AController {

    PlayerPawn pawn;

    public delegate void OnInputAction();
    public static event OnInputAction OnStealthInput;

    MoveComponent move;
    InteractionComponent interaction;

	// Use this for initialization
	void Start ()
    {
        pawn = GetComponent<PlayerPawn>();
        move = GetComponent<MoveComponent>();
        interaction = GetComponent<InteractionComponent>();
	}
	
    void FixedUpdate()
    {        
        if (OnStealthInput != null && (Input.GetButtonDown("crouch") || Input.GetButtonUp("crouch")))
            OnStealthInput();
        if (move)
        {
            float horizontalMove = Input.GetAxis("Horizontal");
            move.HorizontalMove(horizontalMove);

            float verticalMove = Input.GetAxis("Vertical");
            move.VerticalMove(verticalMove);
        }
        if (interaction)
        {
            if (Input.GetButtonDown("use"))
                interaction.CloseInteraction();
        }
    }
}
