namespace MapsAndToolsLibrary.DataAccess;

public class MongoTeamMemberData : ITeamMemberData
{
	private readonly IMongoCollection<TeamMemberModel> _teamMembers;
	private readonly IMemoryCache _cache;
	private const string CacheName = "TeamMembersData";

	public MongoTeamMemberData(IDbConnection db, IMemoryCache cache)
	{
		_cache = cache;
		_teamMembers = db.TeamMemberCollection;
	}

	public async Task<List<TeamMemberModel>> GetAllTeamMembers()
	{
		var output = _cache.Get<List<TeamMemberModel>>(CacheName);
		if (output is null)
		{
			var results = await _teamMembers.FindAsync(_ => true);
			output = results.ToList();

			_cache.Set(CacheName, output, TimeSpan.FromDays(1));
		}

		return output;
	}

	public async Task<TeamMemberModel> GetTeamMeber(string id)
	{
		var results = await _teamMembers.FindAsync(t => t.Id == id);
		return results.FirstOrDefault();
	}

	public Task AddTeamMember(TeamMemberModel teamMember)
	{
		return _teamMembers.InsertOneAsync(teamMember);
	}

	public Task UpdateTeamMember(TeamMemberModel teamMember)
	{
		var filter = Builders<TeamMemberModel>.Filter.Eq("Id", teamMember.Id);
		return _teamMembers.ReplaceOneAsync(filter, teamMember, new ReplaceOptions { IsUpsert = true });
	}

	public Task DeleteTeamMember(string id)
	{
		var filter = Builders<TeamMemberModel>.Filter.Eq("Id", id);
		return _teamMembers.DeleteOneAsync(filter);
	}
}
