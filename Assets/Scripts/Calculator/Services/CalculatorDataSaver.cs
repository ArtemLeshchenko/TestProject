using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Calculator.Model;
using Core;

namespace Calculator.Services
{
    public class CalculatorDataSaver : IStorageService<CalculatorState>
    {
        private readonly string _savePath = Path.Combine(Application.persistentDataPath, "calculator_state.dat");

        public void SaveState(CalculatorState state)
        {
            try
            {
                var formatter = new BinaryFormatter();
                
                using var stream = new FileStream(_savePath, FileMode.Create);

                formatter.Serialize(stream, state);

                Debug.Log("State saved to: " + _savePath);
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error saving state: " + e.Message);
            }
        }
        
        public CalculatorState LoadState()
        {
            try
            {
                if (File.Exists(_savePath))
                {
                    var formatter = new BinaryFormatter();
                    using var stream = new FileStream(_savePath, FileMode.Open);

                    return (CalculatorState)formatter.Deserialize(stream);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error loading state: " + e.Message);
            }
            
            return new CalculatorState();
        }
        
        public void ClearData()
        {
            if (File.Exists(_savePath))
            {
                File.Delete(_savePath);
                Debug.Log($"Data cleared: {_savePath}");
            }
            else
            {
                Debug.Log("No saved data found to clear.");
            }
        }
    }
}