using Microsoft.AspNetCore.Mvc;
using pinterestapi.Model;

namespace pinterestapi.Service.PostService;

public interface IPostInterface
{
    Task<ServiceResponse<PostModel>> GetPostAsync(Guid Id);
    
    Task<ServiceResponse<string>> PostAsync(PostModel post);
}