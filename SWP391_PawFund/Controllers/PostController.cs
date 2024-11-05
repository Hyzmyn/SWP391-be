using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Entities;
using ServiceLayer.Interfaces;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWP391_PawFund.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PostsController : ControllerBase
	{
		private readonly IPostService _postService;

		public PostsController(IPostService postService)
		{
			_postService = postService;
		}

		// GET: api/Posts
		[HttpGet]
		[Authorize]
		public ActionResult<IEnumerable<PostResponseModel>> GetPosts()
		{
			var posts = _postService.GetPosts();
			var response = new List<PostResponseModel>();

			foreach (var post in posts)
			{
				response.Add(new PostResponseModel
				{
					Id = post.Id,
					Title = post.Title,
					Content = post.Content,
					CreateDate = post.CreateDate,
					UpdateDate = post.UpdateDate,
					UserId = post.UserId,
					PetId = post.PetId ?? 0
				});
			}

			return Ok(response);
		}

		// GET: api/Posts/5
		[HttpGet("{id}")]
		[Authorize]
		public async Task<ActionResult<PostResponseDetail>> GetPost(int id)
		{
			var post = await _postService.GetPostByIdAsync(id);

			if (post == null)
			{
				return NotFound();
			}

			var response = new PostResponseDetail
			{
				Id = post.Id,
				Title = post.Title,
				Content = post.Content,
				CreateDate = post.CreateDate,
				UpdateDate = post.UpdateDate,
				UserId = post.UserId,
				PetId = post.PetId,
				User = new UsersResponseModel
				{
					// Populate the User fields here
				},
				FeedBacks = new List<FeedBackResponseModel>() // Populate FeedBacks if needed
			};

			return Ok(response);
		}

		// POST: api/Posts
		[HttpPost]
		[Authorize]
		public async Task<ActionResult> CreatePost(PostRequestModel postRequest)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var post = new Post
			{
				Title = postRequest.Title,
				Content = postRequest.Content,
				UserId = postRequest.UserId,
				PetId = postRequest.PetId,
				CreateDate = DateTime.UtcNow,
				UpdateDate = DateTime.UtcNow
			};

			await _postService.CreatePostAsync(post);

			return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
		}

		// PUT: api/Posts/5
		[HttpPut("{id}")]
		[Authorize]
		public async Task<IActionResult> UpdatePost(int id, PostRequestModel postRequest)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var existingPost = await _postService.GetPostByIdAsync(id);
			if (existingPost == null)
			{
				return NotFound(new { message = "Post not found." });
			}

			existingPost.Title = postRequest.Title;
			existingPost.Content = postRequest.Content;
			existingPost.UserId = postRequest.UserId;
			existingPost.PetId = postRequest.PetId;
			existingPost.UpdateDate = DateTime.UtcNow;

			await _postService.UpdatePostAsync(existingPost);

			return Ok(new { message = "Post updated successfully." });
		}

		// DELETE: api/Posts/5
		[HttpDelete("{id}")]
		[Authorize]
		public async Task<IActionResult> DeletePost(int id)
		{
			var postExists = await _postService.PostExistsAsync(id);
			if (!postExists)
			{
				return NotFound();
			}

			await _postService.DeletePostAsync(id);

			return NoContent();
		}
	}
}
