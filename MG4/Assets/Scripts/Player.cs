using System;
using TMPro;
using UnityEngine;

public enum EquationType
{
    Add, Subtract, Multiply
}

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _equationObject;
    [SerializeField] private TMP_Text _equationText;
    [SerializeField] private TMP_InputField _equationInputField;
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] private FishMovement _movement;
    [SerializeField] private GameObject _correctUI;
    [SerializeField] private GameObject _incorrectUI;
    [SerializeField] private float _incorrectBackwardsMovement;
    [SerializeField] private AudioSource _audio;

    private GameObject _currentFood;
    private EquationType _currentEquationType;
    private int _number1;
    private int _number2;
    private int _points;

    private void OnTriggerEnter(Collider other)
    {
        string operatorCharacter = "";
        if (other.gameObject.tag.Equals("Add"))
        {
            _currentEquationType = EquationType.Add;
            operatorCharacter = "+";
        }
        else if (other.gameObject.tag.Equals("Subtract"))
        {
            _currentEquationType = EquationType.Subtract;
            operatorCharacter = "-";
        }
        else if (other.gameObject.tag.Equals("Multiply"))
        {
            _currentEquationType = EquationType.Multiply;
            operatorCharacter = "x";
        }

        _currentFood = other.gameObject;

        _number1 = UnityEngine.Random.Range(0, 10);
        _number2 = UnityEngine.Random.Range(0, 10);

        _equationText.text = string.Format("{0} {1} {2} = ", _number1, operatorCharacter, _number2);

        _equationObject.SetActive(true);
        _movement.enabled = false;

        // STEP 6 -------------------------------------------------------------
        other.GetComponent<FloatAnimation>().StopAnimation();
        // STEP 6 -------------------------------------------------------------
    }

    public void OnPlayerInput()
    {
        Debug.Log("Player wrote: " + _equationInputField.text);
        _equationObject.SetActive(false);
        _movement.enabled = true;

        bool correct = false;
        if (Int32.TryParse(_equationInputField.text, out int number))
        {
            switch (_currentEquationType)
            {
                case EquationType.Add:
                    correct = CheckIfAdditionCorrect(number);
                    break;
                case EquationType.Subtract:
                    correct = CheckIfSubtractionCorrect(number);
                    break;
                case EquationType.Multiply:
                    correct = CheckIfMultiplicationCorrect(number);
                    break;
            }
        }

        Debug.Log("correct: " + correct);

        if (correct)
        {
            _audio.Play();

            _points += 1;
            _pointsText.text = "points: " + _points;

            _correctUI.SetActive(true);

            Destroy(_currentFood);
        }
        else
        {
            transform.Translate(-transform.forward * _incorrectBackwardsMovement);

            _incorrectUI.SetActive(true);
        }
        _currentFood = null;
    }

    // STEP 3 -----------------------------------------------------------------
    private bool CheckIfAdditionCorrect(int answer)
    {
        return _number1 + _number2 == answer;
    }
    // STEP 3 -----------------------------------------------------------------

    // STEP 4 -----------------------------------------------------------------
    private bool CheckIfSubtractionCorrect(int answer)
    {
        return _number1 - _number2 == answer;
    }
    // STEP 4 -----------------------------------------------------------------

    // STEP 5 -----------------------------------------------------------------
    private bool CheckIfMultiplicationCorrect(int answer)
    {
        return _number1 * _number2 == answer;
    }
    // STEP 5 -----------------------------------------------------------------
}