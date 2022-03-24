using DotNet6API_.Models;
using EF.Core.Repository.Interface.Manager;

namespace DotNet6API_.Interface.Manager
{
    public interface IPostManager:ICommonManager<Post>
    {
        Post GetById(int id);
    }
}