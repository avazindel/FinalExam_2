using UnityEngine;
using TMPro;


public class ScoreBehavior : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private GameObject _player;
    private float _currentScore = 0f;



    // Update is called once per frame
    void Update()
    {
        if (_player.activeSelf)
        {
            if(_player.transform.position.y > _currentScore)
            {
                _currentScore = _player.transform.position.y;
                _currentScoreText.text = _currentScore.ToString("f0");

            }
        }
    }

    public void ResetScores()
    {
        _currentScore = 0f;
      //  _currentScoreText = 0m;

    }

}
