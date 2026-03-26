using TMPro;
using UnityEngine;

namespace Calculator.View
{
    public class HistoryView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _resultText;

        public void WriteHistory(string result) => _resultText.text = result;
    }
}