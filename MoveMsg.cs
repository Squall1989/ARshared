using Riptide;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARshared
{
    public struct MoveMsg : IMessageSerializable
    {
        public int id;
        public Vector3 position;
        public void Deserialize(Message message)
        {
            id = message.GetInt();
            position = message.GetVector3();
        }

        public void Serialize(Message message)
        {
            message.AddInt(id);
            message.AddVector3(position);
        }
    }
}