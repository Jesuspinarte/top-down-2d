using System.Net.NetworkInformation;
using NUnit;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using static UnityEngine.InputManagerEntry;

public class NPC2 : MonoBehaviour
{
    MessageDisplay messageBox;
    Inventory inv;

    private void Start()
    {
        messageBox = GameObject.Find("MessageHandler").GetComponent<MessageDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            inv = coll.gameObject.GetComponent<Inventory>();

            bool hasGold = inv.GetCount("Ring") > 0;
            if (hasGold)
            {
                messageBox.YesNoMessage("I can sell you a powerful scroll for that gold ring.Do you want to buy it ? ", BuyCallback);
            }
            else
            {
                messageBox.ShowMultilineMessage("I have powerful magic to sell, but you have no gold!");
            }
        }
    }

    void BuyCallback(bool answer)
    {
        if (answer)
        {
            inv.Remove("Ring", -1);
            inv.Add("Scroll", 1);
            messageBox.ShowMultilineMessage("Good luck. Remember you must quaff a blue potion before reading the scroll\n" + "I have none but I remember leaving some bya shack near the forest edge");
        }
    }
}
