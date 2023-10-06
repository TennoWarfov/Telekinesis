using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : ActionOnEvent
{
    [SerializeField] private GameObject _teleportionRay;
    private InputDevice _inputDevice;

    protected override void ActionPerformance(object obj)
    {
        SwitchTeleportRay(obj);
    }

    private void SwitchTeleportRay(object obj)
    {
        _inputDevice = (InputDevice)obj;

        _inputDevice.IsPressed(InputHelpers.Button.PrimaryButton, out bool isPressed);
        if (isPressed)
            _teleportionRay.SetActive(true);
        else
            _teleportionRay.SetActive(false);
    }
}
