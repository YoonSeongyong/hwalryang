using UnityEngine;
using System.Collections;

public class popup : MonoBehaviour {
    public GameObject popupobj;
    public GameObject ui;
    private int selecteditem;
    public AudioClip selectsound;
    public GUIText[] itemt;
	// Use this for initialization
	void Start () {
        selecteditem = 1;
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < itemt.Length; i++)
        {
            itemt[i].text = totalmgr.price[i].ToString()+"냥";
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                switch (hit.collider.tag)
                {
                    case "closebutton":
                        AudioSource.PlayClipAtPoint(selectsound,Vector3.zero);
                        closepopup();
                        break;
                    case "shopbutton":
                        AudioSource.PlayClipAtPoint(selectsound, Vector3.zero);
                        showpopup();
                        break;
                    case "powerup":
                        AudioSource.PlayClipAtPoint(selectsound, Vector3.zero);
                        selecteditem = 1;
                        break;
                    case "doubleshot":
                        AudioSource.PlayClipAtPoint(selectsound, Vector3.zero);
                        selecteditem = 2;
                        break;
                    case "speedshot":
                        AudioSource.PlayClipAtPoint(selectsound, Vector3.zero);
                        selecteditem = 3;
                        break;
                    case "buybutton":
                        AudioSource.PlayClipAtPoint(selectsound, Vector3.zero);
                        buy();
                        break;
                }
            }
        }
	}

    void showpopup()
    {
        popupobj.SetActive(true);
        ui.SetActive(false);
        Time.timeScale = 0;
    }
    void closepopup()
    {
        popupobj.SetActive(false);
        ui.SetActive(true);
        Time.timeScale = 1;
    }

    void buy()
    {
        Debug.Log("buy");
        switch(selecteditem)
        {
            case 1:
                if(totalmgr.money>=totalmgr.price[selecteditem-1])
                {
                    totalmgr.money -= totalmgr.price[selecteditem - 1];
                    totalmgr.price[selecteditem - 1] = Mathf.CeilToInt(totalmgr.price[selecteditem - 1] * 1.5f);
                    GameManager.damage+=1f;
                }
                break;
            case 2:
                if (totalmgr.money >= totalmgr.price[selecteditem - 1])
                {
                    totalmgr.money -= totalmgr.price[selecteditem - 1];
                    totalmgr.price[selecteditem - 1] = Mathf.CeilToInt(totalmgr.price[selecteditem - 1] * 1.5f);
                    GameManager.persent += 5;
                }
                break;
            case 3:
                if (totalmgr.money >= totalmgr.price[selecteditem - 1])
                {
                    totalmgr.money -= totalmgr.price[selecteditem - 1];
                    totalmgr.price[selecteditem - 1] = Mathf.CeilToInt(totalmgr.price[selecteditem - 1] * 1.5f);
                    GameManager.shootspeed += 0.05f;
                }
                break;
        }
    }
}
