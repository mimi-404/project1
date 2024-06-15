using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class vehicleController : MonoBehaviour
{
    public WheelJoint2D frontWheel;
    public WheelJoint2D backWheel;
    public float speed = 1500f;
    public float maxMotorTorque = 1000f;

    private JointMotor2D frontMotor;
    private JointMotor2D backMotor;

    private bool accelerate;
    private bool brake;

    void Start()
    {
        frontMotor = new JointMotor2D();
        backMotor = new JointMotor2D();

        // Find buttons in the scene
        GameObject accelerateButton = GameObject.Find("GAS");
        GameObject brakeButton = GameObject.Find("BRAKE");

    }

    void Update()
    {
        if (accelerate)
        {
            // Accelerate
            frontMotor.motorSpeed = -speed;
            backMotor.motorSpeed = -speed;
            frontMotor.maxMotorTorque = maxMotorTorque;
            backMotor.maxMotorTorque = maxMotorTorque;
        }
        else if (brake)
        {
            // Brake
            frontMotor.motorSpeed = speed;
            backMotor.motorSpeed = speed;
            frontMotor.maxMotorTorque = maxMotorTorque;
            backMotor.maxMotorTorque = maxMotorTorque;
        }
        else
        {
            // No input
            frontMotor.motorSpeed = 0;
            backMotor.motorSpeed = 0;
            frontMotor.maxMotorTorque = 0;
            backMotor.maxMotorTorque = 0;
        }

        frontWheel.motor = frontMotor;
        backWheel.motor = backMotor;
    }

    public void Accelerate(bool isPressed)
    {
        accelerate = isPressed;
    }

    public void Brake(bool isPressed)
    {
        brake = isPressed;
    }

    private void AddEventTrigger(GameObject obj, EventTriggerType type, UnityEngine.Events.UnityAction action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = obj.AddComponent<EventTrigger>();
        }

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = type;
        entry.callback.AddListener((eventData) => action());
        trigger.triggers.Add(entry);
    }
}
