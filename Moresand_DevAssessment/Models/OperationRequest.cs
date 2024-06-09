
namespace Moresand_DevAssessment.Models
{
	/// <summary>
	/// Request Model passed to the API Controller
	/// </summary>
	public class OperationRequest
	{
		public List<Operation> Operations { get; set; } = new();
	}

	/// <summary>
	/// Operation/Plugin details which will happen on the image.
	/// </summary>
	public class Operation
	{
		public Operation(Plugin name, Dictionary<string, object> parameters)
		{
			Name = name;
			Parameters = parameters;
		}

		/// <summary>
		/// Name of the Plugin
		/// </summary>
		public Plugin Name { get; set; }

        /// <summary>
        /// Parameters used to apply the plugin
        /// </summary>
        public Dictionary<string, object> Parameters { get; set; }
	}

	/// <summary>
	/// object on which any operation will happen.
	/// </summary>
	public class Image
	{
		public Image(int size)
		{
			Bytes = new byte[size];
		}

		public byte[] Bytes { get; set; }
	}

	public enum Plugin
	{
		None = 0,
		Resize = 1,
		Blur = 2,
		GreyScale = 3
	}
}

