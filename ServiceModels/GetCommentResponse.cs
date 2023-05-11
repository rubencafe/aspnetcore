using Backend.Challenge.Dtos;
using System.Collections.Generic;

namespace Backend.Challenge.ServiceModels
{
    public class GetCommentResponse
    {
        public IList<CommentDto> Comments { get; set; }
    }
}
