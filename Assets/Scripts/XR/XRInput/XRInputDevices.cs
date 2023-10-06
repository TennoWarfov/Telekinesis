using ActionOnEventScript;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

/// <summary>
/// This script is needed in order to get XR Input devices only when this functionality is needed. Just inherit your class from this if you want to get XR input
/// </summary>
public class XRInputDevices : MonoBehaviour, IEvent
{
    public InputDevice InputDevice => _device;
    public InputDeviceCharacteristics Characteristics => _characteristics;
    public IEvent.EventDelegate Event { get; set; }

    [SerializeField] private InputDeviceCharacteristics _characteristics;

    private InputDevice _device;

    private void Start() => TryGetDevices();

    private void Update()
    {
        if (!_device.isValid)
            TryGetDevices();
        else
            Event?.Invoke(_device);
    }

    private void TryGetDevices()
    {
        List<InputDevice> devices = new();
        InputDevices.GetDevicesWithCharacteristics(_characteristics, devices);
        if (devices.Count > 0)
        {
            _device = devices[0];
        }
    }
}
