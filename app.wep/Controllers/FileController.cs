using App.core.Helpers;

namespace App.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {

        private void SetResponse(string contentType, string fileName)
        {
            Response.Clear();
            if (contentType.Length > 0)
            {
                Response.ContentType = contentType;
            }
            Response.Headers.Add("Access-Control-Expose-Headers", new string[]
            {
                "Content-Disposition",
                "X-Suggested-Filename"
            });
            Response.Headers.Add("Content-Disposition", $"attachment; filename={fileName};");
        }

        [HttpPost("download")]
        public async Task<ActionResult> Download(string path)
        {
            await FileUploaderHelper.DownloadFile(Response.Body, SetResponse, path);
            return new EmptyResult();
        }
    }
}
