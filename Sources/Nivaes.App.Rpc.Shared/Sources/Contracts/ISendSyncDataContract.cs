using System.ServiceModel;
using Grpc.Core;
using ProtoBuf.Grpc.Configuration;

namespace Nivaes.App.Rpc;

//[ServiceContract]
[Service]
public interface ISendSyncDataContract
{
    [Operation]
    //ValueTask<string> Echo(string message, ServerCallContext? context = default);
    //[Operation]
    ValueTask<string> Echo(string message);

    //ValueTask<SyncData> GetData(IAsyncStreamReader<SyncData> requestStream, ServerCallContext context = default);
    ValueTask<SyncData> GetData(IAsyncStreamReader<SyncData> requestStream);
}
