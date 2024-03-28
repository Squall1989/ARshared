using Riptide;
using UnityEngine;

namespace ARshared
{

    public struct CreateServerMsg : IMessageSerializable
    {
        public int PrefabId;
        public Vector3 Position;

        public void Deserialize(Message message)
        {
            PrefabId = message.GetInt();
            Position = message.GetVector3();
        }

        public void Serialize(Message message)
        {
            message.AddInt(PrefabId);
            message.AddVector3(Position);
        }
    }
}