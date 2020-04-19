using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

[UpdateBefore(typeof(SimulationSystemGroup))]
public class EventCreation_SystemGroup : ComponentSystemGroup
{

}
