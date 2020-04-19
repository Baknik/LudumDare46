using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

[UpdateAfter(typeof(SimulationSystemGroup))]
public class EventCleanup_SystemGroup : ComponentSystemGroup
{

}
