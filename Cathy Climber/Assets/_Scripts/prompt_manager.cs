using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class prompt_manager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject Canvas;
    public static int tracker = 0;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        switch(tracker)
        {
            case 0: 
                TurnOffFirstMessage();
                return;
            case 1:
                DisplaySecondMessage();
                return;
            case 2:
                TurnOffSecondMessage();
                return;
            default:
                return;
        }
    }

    public void TurnOffSecondMessage()
    {
        if(player.CompareTag("Player"))
        {
            Canvas.transform.GetChild(1).gameObject.SetActive(false); // turn off on second message
            tracker++;
            gameObject.SetActive(false); // turn off trigger;
        }
    }
    public void DisplaySecondMessage()
    {
        if(player.CompareTag("Player"))
        {
            Canvas.transform.GetChild(1).gameObject.SetActive(true); // turn on second message
            tracker++;
            gameObject.SetActive(false); // turn off trigger;
        }
    }

    public void TurnOffFirstMessage()
    {
        if(player.CompareTag("Player"))
        {
            Canvas.transform.GetChild(0).gameObject.SetActive(false); // turn off first tutorial message
            tracker++;
            gameObject.SetActive(false); // turn off trigger;
        }
    }
}
