using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DotNet6API_.Context;
using DotNet6API_.Models;
using DotNet6API_.Manager;
using DotNet6API_.Interface.Manager;
using CoreApiResponse;

namespace DotNet6API_.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
   public class PostController : BaseController
   {
    //    ApplicationDbContext _dbContext;
       IPostManager _postManager;
        // public PostController(ApplicationDbContext dbContext)
        // {
        //     _dbContext = dbContext;
        //     _postManager = new PostManager(dbContext);
        // }

        public PostController(IPostManager postManager)
        {
          _postManager = postManager;
        }

   
      //[Route("[action]")]
      [HttpGet]
      public IActionResult GetAll()
      {
        try
        {
          //var post = _dbContext.Posts.ToList();
          var post = _postManager.GetAll().ToList();
          return CustomResult("Datos cargados correctamente", post);
        }
        catch (Exception ex)
        {
          return BadRequest(ex.Message);
        }
      }

      [HttpGet("id")]
      public IActionResult GetById(int id)
      {
        try
        {
          var post = _postManager.GetById(id);
          if (post==null)
          {
            return CustomResult("Datos no encontrados", HttpStatusCode.NoContent);
          }
          return CustomResult("Dato encontrado", post);
        }
        catch (Exception ex)
        {
          return BadRequest(ex.Message);
        }
      }

      [HttpPost]
      public IActionResult Add(Post post)
      {
        try
        {
          post.CreateDate=DateTime.Now;
          post.UpdateDate=DateTime.Now;
          bool isSaved = _postManager.Add(post);
          //_dbContext.Posts.Add(post);
          //bool isSaved = _dbContext.SaveChanges() > 0;
          if (isSaved)
          {
              return CustomResult("Post creados correctamente", post);
          }
          return CustomResult("Error al crear el Post", HttpStatusCode.BadRequest);
        }
        catch (Exception ex)
        {
          return CustomResult(ex.Message, HttpStatusCode.BadRequest);
        }          
      }

      [HttpPut]
      public IActionResult Edit(Post post)
      {
        try
        {
          var dbPost = _postManager.GetById(post.Id);
          dbPost.Title = post.Title;
          dbPost.Description = post.Description;
          dbPost.UpdateDate = post.UpdateDate;

          if (dbPost.Id == 0)
          {
            return CustomResult("Id no encontrado", HttpStatusCode.BadRequest);
          }

          //post.UpdateDate=DateTime.Now;
          bool isUpdate = _postManager.Update(dbPost);
          if (isUpdate)
          {
            return CustomResult("Post actualizado correctamente", dbPost); 
          }
          return CustomResult("Error al actualizar el Post", HttpStatusCode.BadRequest);
        }
        catch (Exception ex)
        {
          return CustomResult(ex.Message, HttpStatusCode.BadRequest);
        }        
      }

      [HttpDelete("id")]
      public IActionResult Delete(int id)
      {
        try
        {
          var post = _postManager.GetById(id);
          if (post==null)
          {
            return CustomResult("Id no encontrado", HttpStatusCode.NotFound);
          }
          bool isDelete=_postManager.Delete(post);
          if (isDelete)
          {
            return CustomResult("Post eliminado correctamente", HttpStatusCode.OK);
          }
          return CustomResult("Error al eliminar el Post", HttpStatusCode.BadRequest);
        }
        catch (Exception ex)
        {
          return CustomResult(ex.Message, HttpStatusCode.BadRequest);
        }
        
      }
 
   }
}