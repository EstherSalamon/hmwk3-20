using SharingPicsEFCore.Data;

namespace SharingPicsEFCore.Web.Models
{
    public class ViewImageViewModel
    {
        public Picture Picture { get; set; }
        public bool CanLike { get; set; }
    }
}
