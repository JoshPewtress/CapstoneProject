namespace MapsAndToolsLibrary.DataAccess;

public class MongoCallTypeData : ICallTypeData
{
	private readonly IMongoCollection<CallTypeModel> _callTypes;
	private readonly IMemoryCache _cache;
	private const string CacheName = "CallTypesData";

	public MongoCallTypeData(IDbConnection db, IMemoryCache cache)
	{
		_cache = cache;
	}

	public async Task<List<CallTypeModel>> GetAllCallTypes()
	{
		var output = _cache.Get<List<CallTypeModel>>(CacheName);
		if (output is null)
		{
			var results = await _callTypes.FindAsync(_ => true);
			output = results.ToList();

			_cache.Set(CacheName, output);
		}

		return output;
	}

	public Task CreateCallType(CallTypeModel callType)
	{
		return _callTypes.InsertOneAsync(callType);
	}

	public Task UpdateCallType(CallTypeModel callType)
	{
		var filter = Builders<CallTypeModel>.Filter.Eq("Id", callType.Id);
		return _callTypes.ReplaceOneAsync(filter, callType, new ReplaceOptions { IsUpsert = true });
	}
}
