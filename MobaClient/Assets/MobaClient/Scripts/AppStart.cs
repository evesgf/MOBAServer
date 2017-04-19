using UnityEngine;
using System.Collections;

public class AppStart : MonoBehaviour,IResourcesListener {

	// Use this for initialization
	void Start () {

        ResourcesMgr.Create();
        PhotonMgr.Create();
        MessageTipView.Create();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ResourcesMgr.Instance.Load("一个测试用的玩意", typeof(GameObject), this);
        }
    }

    public void OnLoaded(object asset)
    {
        Instantiate<GameObject>(asset as GameObject);
    }
}
