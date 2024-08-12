
namespace chorescore.Services;

public class ChoresService 
{
    private readonly ChoresRepository _choresRepository;

    public ChoresService(ChoresRepository choresRepository)
    {
        _choresRepository = choresRepository;
    }

    public List<Chore> getAllChores()
    {
        List<Chore> Chores = _choresRepository.GetAllChores();
        return Chores;
    }

    public Chore GetChoreById(int choreId)
    {
        Chore chore = _choresRepository.GetChoreById(choreId);
        if (chore == null) throw new Exception($"No chore found with the id of {choreId}");
        return chore;
    }

    public Chore CreateChore(Chore choreData)
    {
        Chore chore = _choresRepository.CreateChore(choreData);
        return chore;
    }

    public string DeleteChore(int choreId)
    {
        Chore choreToDestroy = GetChoreById(choreId);
        _choresRepository.DeleteChore(choreId);

        return $"{choreToDestroy.Name} was destroyed";
    }
}