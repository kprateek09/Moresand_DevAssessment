using Microsoft.AspNetCore.Mvc;
using Moresand_DevAssessment.Models;
using Moresand_DevAssessment.Interfaces;

namespace Moresand_DevAssessment.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class ImageController : ControllerBase
	{
        #region Private variables

        private readonly IPlugingsManager plugingsManager;

        #endregion Private variables

        #region Constructor

        /// <summary>
        /// Constructor for ImageController Controller.
        /// </summary>
        /// <param name="_plugingsManager"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ImageController(IPlugingsManager _plugingsManager)
		{
			plugingsManager = _plugingsManager ?? throw new ArgumentNullException(nameof(_plugingsManager));
		}

        #endregion Constructor

        /// <summary>
        /// Apply the operations provided by the UI on the image
        /// </summary>
        /// <param name="request">OperationRequest model</param>
        /// <returns>IAction</returns>
        [HttpPost("applyPlugin")]
		public IActionResult ApplyOperation([FromBody] OperationRequest request)
		{
			if (request is null)
			{
				return BadRequest("Invalid Input");
			}

			try
			{
				Image image = new(200);
				UsePlugins(image, request.Operations);

				return Ok("Image Operations Done");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception Occured in the ImageController!. Exception Message : {ex.Message}. Exception : {ex}");
				return StatusCode(500, "Error when doing operations on Image");
			}
		}

		private void UsePlugins(Image image, List<Operation> operations)
		{
			foreach (var operation in operations)
			{
				plugingsManager.ApplyPlugin(image, operation.Name, operation.Parameters);
			}
		}
    }
}

