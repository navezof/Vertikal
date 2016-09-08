using UnityEngine;
using System.Collections;


public class Interactable : MonoBehaviour {

    public bool bCloseInteraction;
    public bool bRangeInteraction;

    InteractionComponent interaction;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (bCloseInteraction)
        {
            interaction = col.GetComponent<InteractionComponent>();
            if (interaction)
            {
                interaction.AddInteractable(this.gameObject);
            }
        }
    }

    void OnTriggerExit2D()
    {
        if (interaction)
        {
            interaction.RemoveInteractable(this.gameObject);
            interaction = null;
        }
    }
}
