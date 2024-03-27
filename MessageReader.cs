using ARshared;
using Riptide;
using System;
using System.Collections.Generic;

public class MessageReader 
{
    public delegate void UnionDelegate(IMessageSerializable serializable);
    protected Dictionary<Type, UnionDelegate> callbacksDict = new();

    public virtual void RegisterHandler<T>(Action<T> callback)
    {
        var type = typeof(T);
        if (callbacksDict.ContainsKey(type))
        {
            callbacksDict[type] += (msg) => callback((T)msg);
        }
        else
        {
            callbacksDict.Add(type, (msg) => callback((T)msg));
        }
    }

    public void Read(Message message, ushort msgId)
    {
        switch (msgId)
        {
            case 1:
                InvokeRead(message.GetSerializable<CreateServerMsg>(), typeof(CreateServerMsg));
                break;
            case 2:
                InvokeRead(message.GetSerializable<GpsClientMsg>(), typeof(GpsClientMsg));
                break;
            default:
                throw new Exception("Can't read message with id " +  msgId);
        }

        void InvokeRead(IMessageSerializable msg, Type type)
        {
            if (callbacksDict.TryGetValue(type, out var _delegate))
            {
                _delegate?.Invoke(msg);
            }
        }
    }

}
