using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour
{
    public GameObject bow;
    private int num;
    Quaternion bow_rotate;
    public Camera maincamera;
    // Use this for initialization
    void Start()
    {
        bow_rotate = bow.transform.rotation;
        num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        #region Mouse
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(maincamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null && hit.collider.tag == "UI_Upbutton")
                {
                    num = 1;
                }
                if (hit.collider != null && hit.collider.tag == "UI_Downbutton")
                {
                    num = -1;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                num = 0;
            }
        }
        #endregion
        #region Touch
        else
        {
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Stationary || Input.GetTouch(i).phase == TouchPhase.Moved)
                    {
                        RaycastHit2D hit = Physics2D.Raycast(maincamera.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
                        if (hit.collider != null && hit.collider.tag == "UI_Upbutton")
                        {
                            num = 1;
                        }
                        if (hit.collider != null && hit.collider.tag == "UI_Downbutton")
                        {
                            num = -1;
                        }
                    }
                    else if (Input.GetTouch(i).phase == TouchPhase.Ended)
                    {
                        num = 0;
                    }
                }
            }
        }
        #endregion
        bow_rotate = Quaternion.Euler(new Vector3(0, 0, bow_rotate.eulerAngles.z + num));
        if (bow_rotate.eulerAngles.z > 80f && bow_rotate.eulerAngles.z < 130f)
        {
            bow_rotate = Quaternion.Euler(new Vector3(0, 0, 80f));
        }
        else if (bow_rotate.eulerAngles.z > 130f && bow_rotate.eulerAngles.z < 280f)
        {
            bow_rotate = Quaternion.Euler(new Vector3(0, 0, 280f));
        }
        bow.transform.rotation = bow_rotate;

    }
}
