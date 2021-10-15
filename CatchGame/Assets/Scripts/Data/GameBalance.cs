using UnityEngine;
using System.Collections.Generic;

namespace Scripts.GameBalance
{
    [CreateAssetMenu(fileName = "New GameBalance", menuName = "ScriptableObgects/Menu Game Balance")]
    public class GameBalance : ScriptableObject
    {
        private static GameBalance _instance;
        public static GameBalance Instance
        {
            get
            {
                if (_instance == null)
                {
                    Init();
                }
                return _instance;
            }
        }

        [Header("General Settings")]
        public float PlayerSpeed;
        public float BaseItemSpeed; 
        public int BeginHealth;
        public int MaxHealth;
        public int HealthPoint;

        [Header("Set chance per minute")]
        public List<ItemParams> ItemSettings;

        private static void Init()
        {
            _instance = Resources.Load<GameBalance>("GameBalance");    
        }
    }
}
