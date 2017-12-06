using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.EventSystems;

public class AspectRatio : MonoBehaviour
{
	public bool isOld = true;

    void Update()
    {
		if (EventSystem.current.currentSelectedGameObject.name == "New Game") {
			isOld = false;
		}

		if(EventSystem.current.currentSelectedGameObject.name == "Load Game"){
			isOld = true;
		}

		if (EventSystem.current.currentSelectedGameObject.name == "Start" && isOld == false) {
			if (!Directory.Exists ("C:/Users/Monster/Desktop/" + GameController.control.user_name)) {
				Directory.CreateDirectory ("C:/Users/Monster/Desktop/" + GameController.control.user_name);
				File.Copy ("C:/Users/Monster/Desktop/statusInfo.txt","C:/Users/Monster/Desktop/" + GameController.control.user_name + "/" + GameController.control.user_name + "_statusInfo.txt",true);
			}
		}
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
    }

}