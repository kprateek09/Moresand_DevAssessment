using Moresand_DevAssessment.Interfaces;
using Moresand_DevAssessment.ImageOperations;
using Moresand_DevAssessment.Models;

namespace Moresand_DevAssessment
{
	public class PluginsManager : IPlugingsManager
	{
        #region Private Variables

        private readonly IConfiguration configuration;
		private readonly Dictionary<Plugin, IImageOperation> validOperations = new();

        #endregion Private Variables

        #region Constructor

        /// <summary>
        /// Constructor for PluginsManager class
        /// </summary>
        /// <param name="_config"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public PluginsManager(IConfiguration _config)
		{
			configuration = _config ?? throw new ArgumentNullException(nameof(_config));
			LoadValidOperation();
		}

        #endregion Constructor

        #region Public Methods

        /// <summary>
        /// Get the type of ImageOperation based on pluing name and call it.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="pluginName"></param>
        /// <param name="parameters"></param>
        public void ApplyPlugin(Image image, Plugin pluginName, Dictionary<string, object> parameters)
        {
            try
            {
                validOperations.TryGetValue(pluginName, out IImageOperation? imageOperation);

                if(imageOperation is null)
                {
                    Console.WriteLine($"The given plugin : {pluginName} is not configured to be applied on the image, hence skipping");
                    return;
                }
                imageOperation?.ApplyOperation(image, parameters);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception Occured during choosing to apply the plugin!. Exception Message : {ex.Message}. Exception : {ex}");
                throw;
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Load the valid operations/plugins from appSettings
        /// </summary>
        private void LoadValidOperation()
		{
			var plugins = configuration.GetSection("Plugins");
			foreach(var plugin in plugins.GetChildren())
			{
				switch (plugin.Value)
				{
					case Constants.Resize: validOperations.Add(Plugin.Resize, new ResizeOperation());
						break;
                    case Constants.Blur:
                        validOperations.Add(Plugin.Blur, new BlurOperation());
                        break;
                    case Constants.GreyScale:
                        validOperations.Add(Plugin.GreyScale, new GreyScaleOperation());
                        break;
                }
			}
		}

        #endregion Private Methods
    }
}

