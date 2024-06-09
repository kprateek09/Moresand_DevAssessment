using Moresand_DevAssessment.Models;
using Moresand_DevAssessment.Interfaces;

namespace Moresand_DevAssessment.ImageOperations
{
	public class ResizeOperation : IImageOperation
	{
		#region Private Variables

		private readonly static Plugin Name = Plugin.Resize;

        #endregion Private Variables

        Plugin IImageOperation.Name
		{
			get => Name;
		}

        /// <summary>
        /// Apply the Resize Operation with input parameter on the Image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="operationParameters"></param>
        public void ApplyOperation(Image image, Dictionary<string, object>? operationParameters)
		{
			try
			{
				Console.WriteLine("Resizing Image");
			}
			catch(Exception ex)
			{
                Console.WriteLine($"Exception Occured during Resizing the Image. Exception Message : {ex.Message}. Exception : {ex}");
                throw;
            }
		}
	}
}