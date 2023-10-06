using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RagdollControll : MonoBehaviour
{
    public event Action OnCharacterShotDown;

    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody[] _rigidbodies;
    [SerializeField] private XRGrabInteractable[] _grabInteractables;
    [HideInInspector, SerializeField] private Collider _ragdollTriggerCollider;
    [HideInInspector, SerializeField] private Collider[] _bodyColliders;

    private void Awake()
    {
        IgnoreSelfCollision();
        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = true;
        }

        for (int i = 0; i < _grabInteractables.Length; i++)
        {
            _grabInteractables[i].selectEntered.AddListener(MakePhysicalOnSelect);
            _grabInteractables[i].selectExited.AddListener(MakePhysicalOnDeselect);
        }
    }

    private void IgnoreSelfCollision()
    {
        for (int i = 0; i < _bodyColliders.Length; i++)
        {
            Physics.IgnoreCollision(_ragdollTriggerCollider, _bodyColliders[i], true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        ShotDownCharacter();
    }

    private void ShotDownCharacter()
    {
        MakePhysical();

        OnCharacterShotDown.Invoke();
    }

    private void MakePhysicalOnSelect(SelectEnterEventArgs arg0)
    {
        MakePhysical();
    }
    
    private void MakePhysicalOnDeselect(SelectExitEventArgs arg0)
    {
        MakePhysical();
    }

    private void MakePhysical()
    {
        for (int i = 0; i < _grabInteractables.Length; i++)
        {
            _grabInteractables[i].selectEntered.RemoveListener(MakePhysicalOnSelect);
        }

        _animator.enabled = false;
        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = false;
        }
    }

    private void OnValidate()
    {
        if (_ragdollTriggerCollider == null) _ragdollTriggerCollider = GetComponent<Collider>();
        _rigidbodies ??= GetComponentsInChildren<Rigidbody>();
        _grabInteractables ??= GetComponentsInChildren<XRGrabInteractable>();
        _bodyColliders ??= GetComponentsInChildren<Collider>();
    }
}
