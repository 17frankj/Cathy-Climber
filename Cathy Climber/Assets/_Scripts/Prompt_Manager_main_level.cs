using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Prompt_Manager_main_level : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject NPC;
    public static int tracker_main_level = 0;
   
    void OnCollisionEnter(Collision collision)
    {
        switch(tracker_main_level)
        {
            case 0: 
                TurnOffFirstMessage();
                return;
            case 1:
                //DisplaySecondMessage();
                return;
            case 2:
                //TurnOffSecondMessage();
                return;
            default:
                return;
        }
    }

    public void TurnOffFirstMessage()
    {
        if(player.CompareTag("Player"))
        {
            Canvas.transform.GetChild(0).gameObject.SetActive(false); // turn off first tutorial message
            tracker_main_level++;
            gameObject.SetActive(false); // turn off trigger;
            NPC.SetActive(false); // turn off NPC
        }
    }
}
