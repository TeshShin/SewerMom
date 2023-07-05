using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetBigRat : MonoBehaviour
{
    float timer = 0f;
    bool ticktok = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (ticktok && timer > 1f)
        {
            StoryManager.instance.Death(2);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "fordoor")
        {
            if(StoryManager.instance.player.GetComponent<PlayerMove>().hadCheese && StoryManager.instance.player.GetComponent<PlayerMove>().usebitecheese)
            {
                timer = 0f;
                TextLoader.instance.SetText("BigratNoCheese");
                ticktok = true;
            }
            else if(transform.parent.GetComponent<BigRatMove>().blockplayer)
            {
                TextLoader.instance.SetText("meetbigrat");
            }
        }
    }
}
