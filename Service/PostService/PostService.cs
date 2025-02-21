using pinterestapi.DataContext;
using pinterestapi.Model;
using System;
using System.Threading.Tasks;

namespace pinterestapi.Service.PostService
{
    public class PostService : IPostInterface
    {
        private readonly ApplicationDbContext _context;
        
        public PostService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<ServiceResponse<string>> PostAsync(PostModel post)
        {
            var response = new ServiceResponse<string>();
            try
            {
                await _context.Posts.AddAsync(post);
                await _context.SaveChangesAsync();
                
                response.Data = post.Id.ToString();
                response.Success = true;
                response.Message = "Post successfully added: " + post.ImageBase64.Length + " bytes";
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = "Error to post Post:  " + e.Message;
                Console.WriteLine(e);
                throw;
            }
            return response;
        }
        
        public async Task<ServiceResponse<PostModel>> GetPostAsync(Guid id)
        {
            var response = new ServiceResponse<PostModel>();
            try
            {
                var post = await _context.Posts.FindAsync(id);
                if (post == null)
                {
                    response.Success = false;
                    response.Message = "Post not found";
                    return response;
                }
                response.Data = post;
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = "Error to get post:  " + e.Message;
                Console.WriteLine(e);
                throw;
            }
            return response;
        }
    }
}
