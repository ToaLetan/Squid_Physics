using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControllerManager
{
    public delegate void ButtonPressedEvent(List<string> buttonsPressed);
    public delegate void ButtonHeldEvent(List<string> buttonsHeld);
    public delegate void ButtonReleasedEvent(List<string> buttonsReleased);

    public delegate void AxisEvent(Vector2 axisValue);
    public delegate void TriggerEvent(float axisValue);

    public event ButtonPressedEvent Button_Pressed;
    public event ButtonHeldEvent Button_Held;
    public event ButtonReleasedEvent Button_Released;

    public event AxisEvent Left_Thumbstick_Axis;
    public event AxisEvent Right_Thumbstick_Axis;
    public event AxisEvent DPad_Axis;
    public event TriggerEvent Left_Trigger_Axis;
    public event TriggerEvent Right_Trigger_Axis;

    private const string CONTROLLER_ID = "Controller1 "; //Locked to 1 controller since this currently isn't a multiplayer game!

    public string buttonA = CONTROLLER_ID + "Button A";
    public string buttonB = CONTROLLER_ID + "Button B";
    public string buttonX = CONTROLLER_ID + "Button X";
    public string buttonY = CONTROLLER_ID + "Button Y";

    public string leftBumper = CONTROLLER_ID + "Left Bumper";
    public string rightBumper = CONTROLLER_ID + "Right Bumper";
    public string leftRightTriggers = CONTROLLER_ID + "Left/Right Triggers";

    public string startButton = CONTROLLER_ID + "Start Button";
    public string backButton = CONTROLLER_ID + "Back Button";

    public string leftThumbstickHorizontal = CONTROLLER_ID + "Left Stick Horizontal";
    public string leftThumbstickVertical = CONTROLLER_ID + "Left Stick Vertical";

    public string rightThumbstickHorizontal = CONTROLLER_ID + "Right Stick Horizontal";
    public string rightThumbstickVertical = CONTROLLER_ID + "Right Stick Vertical";

    public string dPadHorizontal = CONTROLLER_ID + "D-Pad Horizontal";
    public string dPadVertical = CONTROLLER_ID + "D-Pad Vertical";

    private static ControllerManager instance = null;

    public static ControllerManager Instance
    {
        get
        {
            if (instance == null)
                instance = new ControllerManager();
            return instance;
        }
    }

    // Use this for initialization
    public ControllerManager()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        UpdateInput();
    }

    private void UpdateInput()
    {
        //========================== Pressed Buttons ==========================
        List<string> allButtonsPressed = new List<string>();
        //ABXY Buttons
        if (Input.GetButtonDown(buttonA))
            allButtonsPressed.Add(buttonA);
        if (Input.GetButtonDown(buttonB))
            allButtonsPressed.Add(buttonB);
        if (Input.GetButtonDown(buttonX))
            allButtonsPressed.Add(buttonX);
        if (Input.GetButtonDown(buttonY))
            allButtonsPressed.Add(buttonY);

        //LR Bumpers
        if (Input.GetButtonDown(leftBumper))
            allButtonsPressed.Add(leftBumper);
        if (Input.GetButtonDown(rightBumper))
            allButtonsPressed.Add(rightBumper);

        //Start/Back Buttons
        if (Input.GetButtonDown(startButton))
            allButtonsPressed.Add(startButton);
        if (Input.GetButtonDown(backButton))
            allButtonsPressed.Add(backButton);

        if (allButtonsPressed.Count > 0)
        {
            if (Button_Pressed != null)
                Button_Pressed(allButtonsPressed);
        }
        //==============================================================

        //========================== Held Buttons ==========================
        List<string> allButtonsHeld = new List<string>();
        //ABXY Buttons
        if (Input.GetButton(buttonA))
            allButtonsHeld.Add(buttonA);
        if (Input.GetButton(buttonB))
            allButtonsHeld.Add(buttonB);
        if (Input.GetButton(buttonX))
            allButtonsHeld.Add(buttonX);
        if (Input.GetButton(buttonY))
            allButtonsHeld.Add(buttonY);

        //LR Bumpers
        if (Input.GetButton(leftBumper))
            allButtonsHeld.Add(leftBumper);
        if (Input.GetButton(rightBumper))
            allButtonsHeld.Add(rightBumper);

        //Start/Back Buttons
        if (Input.GetButton(startButton))
            allButtonsHeld.Add(startButton);
        if (Input.GetButton(backButton))
            allButtonsHeld.Add(backButton);

        if (allButtonsHeld.Count > 0)
        {
            if (Button_Held != null)
                Button_Held(allButtonsHeld);
        }
        //==============================================================

        //========================== Held Buttons ==========================
        List<string> allButtonsReleased = new List<string>();
        //ABXY Buttons
        if (!Input.GetButton(buttonA))
            allButtonsReleased.Add(buttonA);
        if (!Input.GetButton(buttonB))
            allButtonsReleased.Add(buttonB);
        if (!Input.GetButton(buttonX))
            allButtonsReleased.Add(buttonX);
        if (!Input.GetButton(buttonY))
            allButtonsReleased.Add(buttonY);

        //LR Bumpers
        if (!Input.GetButton(leftBumper))
            allButtonsReleased.Add(leftBumper);
        if (!Input.GetButton(rightBumper))
            allButtonsReleased.Add(rightBumper);

        //Start/Back Buttons
        if (!Input.GetButton(startButton))
            allButtonsReleased.Add(startButton);
        if (!Input.GetButton(backButton))
            allButtonsReleased.Add(backButton);

        if (allButtonsReleased.Count > 0)
        {
            if (Button_Released != null)
                Button_Released(allButtonsReleased);
        }
        //==============================================================

        //======================= Thumbstick and Trigger Axes ===========================
        if (Left_Thumbstick_Axis != null)
            Left_Thumbstick_Axis(new Vector2(Input.GetAxis(leftThumbstickHorizontal), Input.GetAxis(leftThumbstickVertical)));

        if (Right_Thumbstick_Axis != null)
            Right_Thumbstick_Axis(new Vector2(Input.GetAxis(rightThumbstickHorizontal), Input.GetAxis(rightThumbstickVertical)));

        if (DPad_Axis != null)
            DPad_Axis(new Vector2(Input.GetAxis(dPadHorizontal), Input.GetAxis(dPadVertical)));

        if (Left_Trigger_Axis != null)
        {
            if (Input.GetAxis(leftRightTriggers) < 0)
                Left_Trigger_Axis(Input.GetAxis(leftRightTriggers));
            if (Input.GetAxis(leftRightTriggers) > 0)
                Right_Trigger_Axis(Input.GetAxis(leftRightTriggers));
        }


        //==============================================================
    }

    //TODO IMMEDIATELY: REFACTOR THIS TO EVENTS
    public bool GetButtonHeld(string buttonName)
    {
        return Input.GetButton(buttonName);
    }

    public bool GetButtonDown(string buttonName)
    {
        return Input.GetButtonDown(buttonName);
    }

    public bool GetButtonUp(string buttonName)
    {
        return Input.GetButtonUp(buttonName);
    }

    public float GetThumbstickAxis(string axisName)
    {
        return Input.GetAxis(axisName);
    }
}
