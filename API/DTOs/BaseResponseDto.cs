using Microsoft.EntityFrameworkCore;

namespace API.DTOs
{
    public class BaseResponseDto
    {
        public int error { get; set; }
        public string message { get; set; }
        public string result { get; set; }
    }

    [Keyless]
    public class ResultDto
    {
        public String data { get; set; }
    }
}
