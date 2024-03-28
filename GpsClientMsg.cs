using Riptide;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARshared
{
    public struct GpsClientMsg : IMessageSerializable
    {
        public float Accuracy;
        public Vector3 Position;

        public void Deserialize(Message message)
        {
            Accuracy = message.GetFloat();
            Position = message.GetVector3();
        }

        public void Serialize(Message message)
        {
            message.AddFloat(Accuracy);
            message.AddVector3(Position);
        }
    }
}