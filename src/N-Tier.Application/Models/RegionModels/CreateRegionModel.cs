using N_Tier.Application.Models;

namespace N_Tier.Application.Models.RegionModels
{
    public class CreateRegionModel
    {
        public string Name { get; set; } = null!;
    }

    public class CreateRegionResponseModel : BaseResponseModel { }

    //public static class ExtensionMetod
    //{
    //    public static IEnumerable<int> Where(this IEnumerable<int> array, Func<int, bool> d)
    //    {
    //        List<int> result = new List<int>();  
    //        foreach (var item in array)
    //        {
    //            if (d(item)) 
    //                result.Add(item);
    //        }
    //        return result;
    //    }
    //}
}