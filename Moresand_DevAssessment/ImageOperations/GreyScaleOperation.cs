using Moresand_DevAssessment.Models;
using Moresand_DevAssessment.Interfaces;

namespace Moresand_DevAssessment.ImageOperations
{
    public class GreyScaleOperation : IImageOperation
    {
        #region Private Variables

        private readonly static Plugin Name = Plugin.GreyScale;

        #endregion Private Variables

        Plugin IImageOperation.Name
        {
            get => Name;
        }

        /// <summary>
        /// Apply the GreyScale Operation on the Image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="operationParameters"></param>
        public void ApplyOperation(Image image, Dictionary<string, object>? operationParameters)
        {
            try
            {
                Console.WriteLine("GreyScaling Image");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception Occured during GreyScaling the Image. Exception Message : {ex.Message}. Exception : {ex}");
                throw;
            }
        }
    }
}