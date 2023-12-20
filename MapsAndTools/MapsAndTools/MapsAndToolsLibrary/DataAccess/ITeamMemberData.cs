
namespace MapsAndToolsLibrary.DataAccess;

public interface ITeamMemberData
{
	Task AddTeamMember(TeamMemberModel teamMember);
	Task DeleteTeamMember(string id);
	Task<List<TeamMemberModel>> GetAllTeamMembers();
	Task<TeamMemberModel> GetTeamMeber(string id);
	Task UpdateTeamMember(TeamMemberModel teamMember);
}