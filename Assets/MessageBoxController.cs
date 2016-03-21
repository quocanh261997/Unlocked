using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageBoxController : MonoBehaviour {
    public const int MODE_CONF_QUIT = 0;
    public const int MODE_CONF_SKIP_MISSION = 1;
    public const int MODE_MESSAGE = 2;
    public Text lblTitle;
    public Text lblMessage;
    public Button btnOk;
    public Button btnCancel;
    Canvas wasFocus;
    int mode;
    public void InitMessageBox(int mode,string title, string message)
    {
        this.mode = mode;
        lblTitle.text = title;
        lblMessage.text = message;
        if (mode == 2)
        {
            btnCancel.gameObject.SetActive(false);
            //btnOk.transform.position = new Vector3(0, btnOk.transform.position.y);
            btnOk.transform.localScale = new Vector3(2.2f, 1,1);
        }
        else {
            btnCancel.gameObject.SetActive(true);
            btnOk.transform.localScale = new Vector3(1, 1,1);
        }
        transform.parent.GetComponent<Canvas>().planeDistance = 50;
        foreach (Canvas c in GameObject.FindObjectsOfType<Canvas>())
        {
            if (c.GetComponent<GraphicRaycaster>().enabled) wasFocus = c;
            if (c.name == transform.parent.name)
            {
                c.GetComponent<GraphicRaycaster>().enabled = true;
            }
            else c.GetComponent<GraphicRaycaster>().enabled = false;
        }
    }
    public void OkPressed()
    {
        switch (mode)
        {
            case MODE_CONF_QUIT:
                Application.Quit();
                break;
            case MODE_CONF_SKIP_MISSION:
				if (AdMob.adForSkip != null && AdMob.adForSkip.IsLoaded())
                {
					AdMob.adForSkip.Show();
                }
                else
                {
                    //InitMessageBox(2, "Error", "Sorry, something's going on, we couldn't load ads");
                }
                break;
        }
        resetPos();
    }
    public void CancelPressed()
    {
        switch (mode)
        {
            case MODE_CONF_QUIT:
                break;
            case MODE_CONF_SKIP_MISSION:
                break;
        }
        resetPos();
    }
    void resetPos()
    {
        transform.parent.GetComponent<Canvas>().planeDistance = 200;
        foreach (Canvas c in GameObject.FindObjectsOfType<Canvas>())
        {
            c.GetComponent<GraphicRaycaster>().enabled = false;
        }
		wasFocus.GetComponent<GraphicRaycaster>().enabled = true;
    }
}
