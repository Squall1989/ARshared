using Riptide;
using UnityEngine;

namespace ARshared
{

    public struct CreateServerMsg : IMessageSerializable
    {
        public int PrefabId;
        public GlobalPosition Position;

        public void Deserialize(Message message)
        {
            PrefabId = message.GetInt();
            Position = message.GetGlobalPosition();
        }

        public void Serialize(Message message)
        {
            message.AddInt(PrefabId);
            message.AddGlobalPosition(Position);
        }
    }
}