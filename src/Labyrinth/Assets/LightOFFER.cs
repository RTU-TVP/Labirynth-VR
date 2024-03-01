using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOFFER : MonoBehaviour
{
    public void OFF() { FindAnyObjectByType<ElectricTorchOnOff>().OffLight(); }
}
