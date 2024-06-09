using Moresand_DevAssessment.Models;

namespace Moresand_DevAssessment.Interfaces
{
	public interface IPlugingsManager
	{
        /// <summary>
        /// Get the type of ImageOperation based on pluing name and call it.
        /// </summary>
        /// <param name="image">Image on which opertion will happen</param>
        /// <param name="pluginName">Plugin Name</param>
        /// <param name="parameters">Parameter used to apply the plugin</param>
        public void ApplyPlugin(Image image, Plugin pluginName, Dictionary<string, object> parameters);
	}
}

