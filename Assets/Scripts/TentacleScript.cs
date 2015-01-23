using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TentacleScript : MonoBehaviour 
{
    private const float MOVESPEED = 1.5f;

    private ControllerManager playerController = ControllerManager.Instance;

    //Button indicators
    private GameObject buttonA = null;
    private GameObject buttonB = null;
    private GameObject buttonX = null;
    private GameObject buttonY = null;

    private GameObject activeTentacle = null;
    private GameObject activeTentacleEnd = null;

    private Rigidbody activeTentacleEndRigidbody = null;

	// Use this for initialization
	void Start () 
    {
        playerController.Button_Pressed += OnButtonPress;
        playerController.Left_Thumbstick_Axis += OnLeftThumbstickMovement;

        buttonA = GameObject.Find("XBONE_A");
        buttonB = GameObject.Find("XBONE_B");
        buttonX = GameObject.Find("XBONE_X");
        buttonY = GameObject.Find("XBONE_Y");
	}
	
	// Update is called once per frame
	void Update () 
    {
        playerController.Update();
	}

    private void OnButtonPress(List<string> buttonsPressed)
    {
        if (buttonsPressed.Contains(playerController.buttonA))
        {
            activeTentacle = GameObject.Find("Tentacle_A");
            activeTentacleEnd = activeTentacle.transform.FindChild("TentacleEnd").gameObject;
            activeTentacleEndRigidbody = activeTentacleEnd.GetComponent<Rigidbody>();

            HighlightButton("XBONE_A");
        }

        if (buttonsPressed.Contains(playerController.buttonB))
        {
            activeTentacle = GameObject.Find("Tentacle_B");
            activeTentacleEnd = activeTentacle.transform.FindChild("TentacleEnd").gameObject;
            activeTentacleEndRigidbody = activeTentacleEnd.GetComponent<Rigidbody>();

            HighlightButton("XBONE_B");
        }

        if (buttonsPressed.Contains(playerController.buttonX))
        {
            activeTentacle = GameObject.Find("Tentacle_X");
            activeTentacleEnd = activeTentacle.transform.FindChild("TentacleEnd").gameObject;
            activeTentacleEndRigidbody = activeTentacleEnd.GetComponent<Rigidbody>();

            HighlightButton("XBONE_X");
        }

        if (buttonsPressed.Contains(playerController.buttonY))
        {
            activeTentacle = GameObject.Find("Tentacle_Y");
            activeTentacleEnd = activeTentacle.transform.FindChild("TentacleEnd").gameObject;
            activeTentacleEndRigidbody = activeTentacleEnd.GetComponent<Rigidbody>();

            HighlightButton("XBONE_Y");
        }
    }

    private void OnLeftThumbstickMovement(Vector2 axisValue)
    {
        if (activeTentacle != null)
        {
            if (axisValue != Vector2.zero)
            {
                activeTentacleEndRigidbody.transform.position += new Vector3(axisValue.x, axisValue.y, 0) * MOVESPEED * Time.deltaTime;
            }
            else
                activeTentacleEndRigidbody.angularVelocity = Vector2.zero;
        }
    }

    private void HighlightButton(string buttonToHighlight)
    {
        switch(buttonToHighlight)
        {
            case "XBONE_A":
                buttonA.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Active_XBONE_A");

                buttonB.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/XBONE_B");
                buttonX.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/XBONE_X");
                buttonY.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/XBONE_Y");
                break;
            case "XBONE_B":
                buttonB.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Active_XBONE_B");

                buttonA.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/XBONE_A");
                buttonX.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/XBONE_X");
                buttonY.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/XBONE_Y");
                break;
            case "XBONE_X":
                buttonX.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Active_XBONE_X");

                buttonA.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/XBONE_A");
                buttonB.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/XBONE_B");
                buttonY.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/XBONE_Y");
                break;
            case "XBONE_Y":
                buttonY.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Active_XBONE_Y");

                buttonA.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/XBONE_A");
                buttonB.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/XBONE_B");
                buttonX.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/XBONE_X");
                break;
        }
    }
}
