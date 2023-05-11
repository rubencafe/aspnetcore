using Backend.Challenge.Contracts;
using Backend.Challenge.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Challenge.Controllers
{
    public class MainController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICommentService _commentService;

        public MainController(IUserService userService, ICommentService commentService)
        {
            _userService = userService;
            _commentService = commentService;
        }

        [HttpGet]
        public IActionResult Users(int[] id)
        {
            var response = _userService.GetUsers(id);
            return response.Users.Count > 0 ? Ok(response) : NotFound($"User not found");
        }

        [HttpPost]
        public IActionResult Users([FromBody] UserDto user)
        {
            _userService.CreateUser(user);
            return Ok($"User with id {user.Id} created");
        }

        [HttpGet]
        public IActionResult Comments(string entityId, int page, int pageSize)
        {
            var result = _commentService.GetCommentPage(entityId, page, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Comments([FromBody] CommentDto comment)
        {
            _commentService.CreateComment(comment);
            return Ok($"Comment created successfuly on Entity {comment.Entity} by user {comment.UserId}");
        }

        [HttpGet]
        public IActionResult NewComments(string entityId, string userId)
        {
            var response = _commentService.GetNewComments(entityId, userId);
            return Ok(response);
        }
    }
}