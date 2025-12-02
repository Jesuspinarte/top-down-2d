using System.Collections;
using TMPro;
using UnityEngine;

public class MessageDisplay : MonoBehaviour
{
    public Transform messageUI;
    TextMeshProUGUI textObject;

    private void Start()
    {
        textObject = messageUI.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    IEnumerator DoMessage(string message, float seconds)
    {
        messageUI.gameObject.SetActive(true);
        textObject.text = message;
        yield return new WaitForSeconds(seconds);
        messageUI.gameObject.SetActive(false);
    }

    IEnumerator DoMultilineMessage(string message)
    {
        messageUI.gameObject.SetActive(true);
        string[] lines = message.Split('\n');

        foreach (string line in lines)
        {
            textObject.text = line;
            yield return null;

            while (true)
            {
                if (Input.GetButtonDown("Fire1"))
                    break;
                yield return null;
            }
        }

        messageUI.gameObject.SetActive(false);
    }

    public void ShowMessage(string message, float seconds)
    {
        StartCoroutine(DoMessage(message, seconds));
    }

    public void ShhowMultineMessage(string message) {
        StartCoroutine(DoMultilineMessage(message));
    }
}
