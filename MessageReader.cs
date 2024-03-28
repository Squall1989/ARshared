using ARshared;
using Riptide;
using System;
using System.Collections.Generic;

public class MessageReader 
{
    public delegate void UnionDelegate(IMessageSerializable serializable);
    protected delegate void UnionConnectDelegate(IMessageSerializable message, Connection connection);
    protected Dictionary<Type, UnionDelegate> callbacksDict = new();
    protected Dictionary<Type, UnionConnectDelegate> callbacksConnectDict = new();

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

    public virtual void RegisterHandler<T>(Action<T, Connection> callback)
    {
        var type = typeof(T);
        if (callbacksDict.ContainsKey(type))
        {
            callbacksConnectDict[type] += (msg, connect) => callback((T)msg, connect);
        }
        else
        {
            callbacksConnectDict.Add(type, (msg, connect) => callback((T)msg, connect));
        }
    }

    public void Read(Message message, ushort msgId, Connection connection = null)
    {
        switch (msgId)
        {
            case 1:
                InvokeRead(message.GetSerializable<CreateServerMsg>(), typeof(CreateServerMsg), connection);
                break;
            case 2:
                InvokeRead(message.GetSerializable<GpsClientMsg>(), typeof(GpsClientMsg), connection);
                break;
            default:
                throw new Exception("Can't read message with id " +  msgId);
        }        
    }
    void InvokeRead(IMessageSerializable msg, Type type, Connection connection = null)
    {
        if (callbacksDict.TryGetValue(type, out var _delegate))
        {
            _delegate?.Invoke(msg);
        }
        
        if (connection != null && callbacksConnectDict.TryGetValue(type, out var unionConnectDelegate))
        {
            unionConnectDelegate?.Invoke(msg, connection);
        }
    }
}
