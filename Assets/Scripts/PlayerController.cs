using UnityEngine;
using System.Collections;

public class PlayerController : AController {

    PlayerPawn pawn;
    StealthComponent stealth;
    MoveComponent move;
    InteractionComponent interaction;

	// Use this for initialization
	void Start ()
    {
        pawn = GetComponent<PlayerPawn>();
        stealth = GetComponent<StealthComponent>();
        move = GetComponent<MoveComponent>();
        interaction = GetComponent<InteractionComponent>();
	}
	
    void FixedUpdate()
    {
        if (stealth)
        {
            if (Input.GetButtonDown("crouch"))
                stealth.EnterStealth();
            if (Input.GetButtonUp("crouch"))
                stealth.ExitStealth();
        }
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
