
namespace BlogManager.Services
{
    public interface IServiceFactory
    {
        ICategoryService GetCategoryService();
        IPostService GetPostService();
    }
}
