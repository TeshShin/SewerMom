using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class HideOn : MonoBehaviour
{
    private float waitforhide = 0; 
    public bool hide = false;
    private PlayerMove thePlayer;
    public GameObject flashLight;
    public GameObject lockerOpen;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hide)
        {
            waitforhide += Time.deltaTime;
            if(waitforhide > 1 && thePlayer.IsKeydown)
            {
                thePlayer.animator.SetFloat("DirX", 0);
                thePlayer.animator.SetFloat("DirY", -1f);   // 라커 나올 때 아래 방향 보면서 나옴
                flashLight.SetActive(true);
                thePlayer.inhide = false;
                hide = false;
                Invoke("Lockerclose", 0.2f);    // 라커 문 닫힘
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ToDoor" && thePlayer.IsKeydown)
        {
            lockerOpen.SetActive(true);
            thePlayer.inhide = true;
            thePlayer.animator.SetFloat("DirX", 0);
            thePlayer.animator.SetFloat("DirY", 1f);    // 라커 들어갈때 위방향보면서 들어감
            Invoke("HideonLocker", 1);
        }
    }
    private void HideonLocker()
    {
        waitforhide = 0;
        flashLight.SetActive(false);
        hide = true;
    }
    private void Lockerclose()
    {
        lockerOpen.SetActive(false);
    }
}
