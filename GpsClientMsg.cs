using Riptide;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARshared
{
    public struct GpsClientMsg : IMessageSerializable
    {
        public float Accuracy;
        public GlobalPosition Position;

        public void Deserialize(Message message)
        {
            Accuracy = message.GetFloat();
            Position = message.GetGlobalPosition();
        }

        public void Serialize(Message message)
        {
            message.AddFloat(Accuracy);
            message.AddGlobalPosition(Position);
        }
    }
}