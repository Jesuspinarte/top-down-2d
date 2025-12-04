using UnityEngine;
using static UnityEngine.InputManagerEntry;

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
            //messageBox.ShhowMultineMessage("Hi Adventurer!\nI'm glad you have come to this little town.\nOur Story begins now, are you ready for your new challenges?");
            //messageBox.YesNoMessage("Hi Adventurer!\nI'm glad you have come to this little town.\nOur Story begins now, are you ready for your new challenges?", AnswerFunc);

            Inventory inv = coll.gameObject.GetComponent<Inventory>();
            bool hasScroll = inv.GetCount("Scroll") > 0;
            bool hasPotion= inv.GetCount("Potion") > 0;

            if (!hasScroll && !hasPotion) {
                messageBox.ShowMultilineMessage("You want to cross the river? This stone has been here many years\n"
                    + "It is too heavy for any on the island to move. Only magic will move it.\n"
                    + "There is an old lady in the forest who may help, but she will need to be paid");
            }
            else if (hasScroll && !hasPotion)
            {
                messageBox.ShowMultilineMessage("Ah, you have the scroll but it is useless without quaffing the blue potion.\n You must find the blue potion");
 }
            else if (hasScroll && hasPotion)
            {
                messageBox.YesNoMessage("Aha, you have the magic to move the stone. Would you like to quaff the potion and read the scroll ? ", MagicCallback);
            }
        }
    }

    void AnswerFunc(bool answer)
    {
        if (answer)
            messageBox.ShowMultilineMessage("Brilliant!\nI wish you the best on your journey!");
        else
            messageBox.ShowMultilineMessage("So weak!\nI should have trusted the other guy...");
    }

    void MagicCallback(bool answer)
    {
        if (answer)
        {
            GameObject obstacle = GameObject.Find("Obstacle");
            obstacle.transform.GetChild(0).gameObject.SetActive(false);
            obstacle.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
