using UnityEngine;

public class NPC1 : MonoBehaviour
{
    MessageDisplay messageBox;

    private void Start()
    {
        messageBox = GameObject.Find("MessageHandler").GetComponent<MessageDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            messageBox.ShhowMultineMessage("Hi Adventurer!\nI'm glad you have come to this little town.\nOur Story begins now, are you ready for your new challenges?");
        }
    }
}
