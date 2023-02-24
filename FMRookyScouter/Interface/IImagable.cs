using FMRookyScouter.Helper;

namespace FMRookyScouter.Interface
{
    public interface IImagable
    {
        string Name { get; }
        string Image { get; }
    }

    public static class ImagableExt
    {
        public static string GetImagePath(this IImagable imagable)
        {
            var prefix = "/FMRookyScouter;component/Image/Logo";
            var ext = "png";
            var type = imagable.GetType();

            return $"{prefix}/{type.Name}/{imagable.Name.TrimEnglish()}.{ext}";
        }
    }
}
