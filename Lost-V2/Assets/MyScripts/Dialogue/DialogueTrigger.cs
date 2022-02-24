
public class DialogueTrigger : Interactable {


    public override string GetDescription()
    {
        return "Press [E] to talk to the mage";
    }

    public override void Interact()
    {
        TriggerDialogue();
    }

    public void TriggerDialogue ()
	{
		
	}

}
