using System.ServiceModel;
using Grpc.Core;
using MagicOnion;

namespace Nivaes.App.Rpc;

public interface ISendSyncDataService : IService<ISendSyncDataService>
{

    UnaryResult<string> Echo(string message);

    ////ValueTask<SyncData> GetData(IAsyncStreamReader<SyncData> requestStream, ServerCallContext context = default);
    //ValueTask<SyncData> GetData(IAsyncStreamReader<SyncData> requestStream);
}
