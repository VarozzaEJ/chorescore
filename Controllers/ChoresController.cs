namespace chorescore.Controllers;

[ApiController]
[Route("api/chores")]
public class ChoresController : ControllerBase {

    private readonly ChoresService _choresService;

    public ChoresController(ChoresService choresService)
    {
        _choresService = choresService;
    }


    [HttpGet]
    public ActionResult<List<Chore>> GetAllChores()
    {
        try
        {
            List<Chore> chores = _choresService.getAllChores();
            return Ok(chores);
        }
        catch(Exception exception)
        {
            return BadRequest(exception.Message); 
        }
    }

    [HttpGet("{choreId}")]

    public ActionResult<Chore> GetChoreById(int choreId)
    {
        try
        {
            Chore chore = _choresService.GetChoreById(choreId);
            return Ok(chore);
        }
        catch(Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpPost]
    public ActionResult<Chore> CreateChore([FromBody] Chore choreData)
    {
        try
        {
            Chore chore = _choresService.CreateChore(choreData);
            return Ok(chore);
        }
        catch(Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpDelete("{choreId}")]

    public ActionResult<string> DeleteChore(int choreId)
    {
        try
        {
            string message = _choresService.DeleteChore(choreId);
            return Ok(message);
        }
        catch(Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
}