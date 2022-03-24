using DotNet6API_.Context;
using DotNet6API_.Interface.Manager;
using DotNet6API_.Models;
using DotNet6API_.Repository;
using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;

namespace DotNet6API_.Manager
{
    public class PostManager : CommonManager<Post>, IPostManager
    {
        public PostManager(ApplicationDbContext _dbContext) : base(new PostRepository(_dbContext))
        {
        }

        public Post GetById(int id)
        {
            return GetFirstOrDefault( x => x.Id == id);
        }

        
    }
} 