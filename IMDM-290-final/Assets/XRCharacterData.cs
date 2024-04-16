using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public static class XRCharacterData {
    public static PositionData LeftHand { get; private set; }
    public static PositionData RightHand { get; private set; }

    public static ControllerData LeftController { get; private set; }
    public static ControllerData RightController { get; private set; }
    public static DeviceData HMD { get; private set; }


    static XRCharacterData() {
        LeftHand = new PositionData();
        RightHand = new PositionData();

        LeftController = new ControllerData(
            InitializeInputDevice(
                InputDeviceCharacteristics.Controller | 
                InputDeviceCharacteristics.Left));
                
        RightController = new ControllerData(
            InitializeInputDevice(
                InputDeviceCharacteristics.Controller | 
                InputDeviceCharacteristics.Right));
                
        HMD = new DeviceData(
            InitializeInputDevice(
                InputDeviceCharacteristics.HeadMounted));
    }

    private static InputDevice InitializeInputDevice(InputDeviceCharacteristics inputCharacteristics)
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(inputCharacteristics, devices);

        if (devices.Count > 0)
            return devices[0];

        return new InputDevice();
    }
}

public class DeviceData {
    public static InputDevice Device { get; private set; }
    
    public Vector3 Velocity {
        get { 
            Device.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 val); 
            return val;
        }
    }
    public Vector3 AngularVelocity {
        get { 
            Device.TryGetFeatureValue(CommonUsages.deviceAngularVelocity, out Vector3 val); 
            return val;
        }
    }
    public Vector3 Position {
        get { 
            Device.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 val); 
            return val;
        }
    }
    public Quaternion Rotation {
        get { 
            Device.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion val); 
            return val;
        }
    }
    
    private DeviceData() {}
    public DeviceData(InputDevice controller) {
        Device = controller;
    }
}

public class ControllerData : DeviceData {
    public float Trigger {
        get { 
            Device.TryGetFeatureValue(CommonUsages.trigger, out float val); 
            return val;
        }
    }
    public float Grip {
        get { 
            Device.TryGetFeatureValue(CommonUsages.grip, out float val); 
            return val;
        }
    }

    public ControllerData(InputDevice device) : base(device) {}
}


public class PositionData {
    private Vector3 position;
    private Vector3 localPosition;
    private Vector3 lastPosition;
    private Vector3 lastLocalPosition;

    public Vector3 Position {
        get { return position; }
    }
    public Vector3 LocalPosition {
        get { return localPosition; }
    }
    public Vector3 PositionDelta
    {
        get { return position - lastPosition; }
    }
    public Vector3 LocalPositionDelta
    {
        get { return localPosition - lastLocalPosition; }
    }

    public void Update(Vector3 position, Vector3 localPosition) {
        lastPosition = this.position;
        lastLocalPosition = this.localPosition;
        this.position = position;
        this.localPosition = localPosition;
    }
}
