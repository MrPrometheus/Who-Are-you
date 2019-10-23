using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

[DataContract]
public class DialogSet
{
    [DataMember]
    public int CountBallsForNextLevel = 0;
    [DataMember]
    public Dialog[] DialogSets;

}

