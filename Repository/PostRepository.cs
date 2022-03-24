using DotNet6API_.Context;
using DotNet6API_.Interface.Repository;
using DotNet6API_.Models;
using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace DotNet6API_.Repository
{
    public class PostRepository : CommonRepository<Post>,IPostRepository
    {
        public PostRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}