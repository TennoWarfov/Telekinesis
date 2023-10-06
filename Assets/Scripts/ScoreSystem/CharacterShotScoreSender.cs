using TMPro;
using UnityEngine;

public class CharacterShotScoreSender : ScoreSender
{
    [SerializeField] private RagdollControll _ragdollControll;
    [SerializeField] private Popup _scorePopup;
    [SerializeField] private Transform _popupsParent;

    private void Awake()
    {
        _ragdollControll.OnCharacterShotDown += SendScore;
    }

    private void OnDestroy()
    {
        _ragdollControll.OnCharacterShotDown -= SendScore;
    }

    protected override void SendScore()
    {
        base.SendScore();
        _scorePopup = Instantiate(_scorePopup, _popupsParent.position, Quaternion.identity, _popupsParent);
        _scorePopup.Initialize();

        TextMeshProUGUI scoreText = _scorePopup.GetComponentInChildren<TextMeshProUGUI>();
        scoreText.text = $"+{_score}";
    }
}
