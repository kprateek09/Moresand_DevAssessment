using Moresand_DevAssessment.Models;

namespace Moresand_DevAssessment.Interfaces
{
	public interface IImageOperation
	{
		//Name of the Image Operation/Plugin
		Plugin Name { get; }

        /// <summary>
        /// Apply the operation using the parameters on image.
        /// </summary>
        /// <param name="image">Image on which opertion will happen</param>
        /// <param name="operationParameters">Parameter used to apply the plugin</param>
        void ApplyOperation(Image image, Dictionary<string, object>? operationParameters = null);
	}
}