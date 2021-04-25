using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class QuoteData : ScriptableObject
{
    public QuoteId id;
    public List<string> texts;
    
    public enum QuoteId
    {
        Q_00_General,
        Q_01_Nazis,
        Q_02_BillGates,
        Q_03_Covid,
        Q_04_Vaccin,
        Q_05_Qanon,
        Q_06_FlatEarth,
        Q_07_Chemtrails,
        Q_08_Holocaust,
        Q_09_Climate,
        Q_10_Illuminati,
        Q_11_AnimalSpies,
        Q_12_Misc
    }
}
