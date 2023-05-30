using IExamSystemCore.Implementation;
using IExamSystemCore.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IExamSystem.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class IExamSystemController : ControllerBase
{
    private static readonly IExamSystemCore.Interface.IExamSystem iExamSystem = new CoarseGrainedHashSetImplementation();

    [HttpGet(Name = "FindStudent")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<bool> FindStudent(long studentId, long courseId)
    {
        bool found;

        try
        {
            found = iExamSystem.Contains(studentId, courseId);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }

        return Ok(found);
    }

    [HttpPost(Name = "AddStudent")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult AddStudent(long studentId, long courseId)
    {
        try
        {
            iExamSystem.Add(studentId, courseId);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }

        return Ok();
    }

    [HttpDelete(Name = "RemoveStudent")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult RemoveStudent(long studentId, long courseId)
    {
        try
        {
            iExamSystem.Remove(studentId, courseId);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }

        return Ok();
    }

    [HttpGet(Name = "GetStudentsCount")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<int> GetStudentsCount()
    {
        int count;

        try
        {
            count = iExamSystem.Count;
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }

        return Ok(count);
    }
}
