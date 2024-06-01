using UnityEngine;
using UnityEngine.UI;

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
        Button accelerateButton = GameObject.Find("GAS").GetComponent<Button>();
        Button brakeButton = GameObject.Find("BRAKE").GetComponent<Button>();

        // Add listeners to the buttons
        accelerateButton.onClick.AddListener(() => Accelerate(true));
        accelerateButton.onClick.AddListener(() => Brake(false));
        brakeButton.onClick.AddListener(() => Brake(true));
        brakeButton.onClick.AddListener(() => Accelerate(false));
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
}
