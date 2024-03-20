using Riptide;
using UnityEngine;

namespace ARshared
{

    public struct CreateMsg : IMessageSerializable
    {
        public int prefabId;
        public MoveMsg moveMsg;

        public void Deserialize(Message message)
        {
            prefabId = message.GetInt();
            moveMsg = message.GetSerializable<MoveMsg>();
        }

        public void Serialize(Message message)
        {
            message.AddInt(prefabId);
            message.AddSerializable(moveMsg);
        }
    }
}