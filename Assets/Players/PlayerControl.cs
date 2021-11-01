using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = gameObject.GetComponent<PlayerController>();
        if(_playerController == null)
        {
            Debug.LogError("Need player controller");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseClick();
        }

        if (Input.GetKeyDown("space"))
        {
            MessageSystem.Instance.TriggerEvent("SwitchPlayerLay");
        }
    }

    private void MouseClick()
    {
        

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitinfo;

        if (Physics.Raycast(ray, out hitinfo, 10000))
        {
            if (hitinfo.collider.tag == "Tile")
            {
                _playerController.DestPoint = new Vector3(hitinfo.point.x, transform.position.y, hitinfo.point.z);
                MessageSystem.Instance.TriggerEvent("SwitchPlayerMove");
                //_playerController.MoveToPosition(hitinfo.point);
            }
        }
    }
}
