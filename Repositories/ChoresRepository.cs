


namespace chorescore.Repositories;

public class ChoresRepository
{
    private readonly IDbConnection _db;

    public ChoresRepository(IDbConnection db)
    {
        _db = db;
    }
    public List<Chore> GetAllChores()
    {
        string sql = "SELECT * FROM chores;";
        List<Chore> chores = _db.Query<Chore>(sql).ToList();
        return chores;
    }

    public Chore CreateChore(Chore choreData)
    {
        string sql = @"
        INSERT INTO
        chores (name, description, isComplete, timeToComplete)
        VALUES (@name, @description, @isComplete, @timeToComplete);

        SELECT * FROM chores where id = LAST_INSERT_ID()
        ;";

        Chore chore = _db.Query<Chore>(sql, choreData).FirstOrDefault();
        return chore;
    }

    public Chore GetChoreById(int choreId)
    {
        string sql = "SELECT * FROM chores WHERE id = @choreId;";
        Chore chore = _db.Query<Chore>(sql, new {choreId = choreId}).FirstOrDefault();
        return chore;
    }

    public void DeleteChore(int choreId)
    {
        string sql = "DELETE FROM chores WHERE id = @choreId LIMIT 1;";

        int rowsAffected = _db.Execute(sql, new {choreId});

        if(rowsAffected == 0) throw new Exception( "could not delete chore");

        if(rowsAffected == 2) throw new Exception("Deleted too many homie");
    }
}