
namespace MapsAndToolsLibrary.DataAccess;

public interface ICallTypeData
{
	Task CreateCallType(CallTypeModel callType);
	Task<List<CallTypeModel>> GetAllCallTypes();
	Task UpdateCallType(CallTypeModel callType);
}