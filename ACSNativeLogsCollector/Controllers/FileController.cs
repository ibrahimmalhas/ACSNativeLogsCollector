using Microsoft.AspNetCore.Mvc;

namespace FileStorageApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {

        [HttpPost("uploadblog")]
        public async Task<IActionResult> UploadFileblog()
        {

            try
            {
                // Read the file from the request body
                using (var memoryStream = new MemoryStream())
                {
                    await Request.Body.CopyToAsync(memoryStream);
                    var fileBytes = memoryStream.ToArray();

                    // Generate a unique file name based on current date and time
                    var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                    var fileName = $"Blog_{timestamp}.blog"; 


                    var relativeFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "SavedFiles");
                    if (!Directory.Exists(relativeFolderPath))
                    {
                        Directory.CreateDirectory(relativeFolderPath);
                    }


                    // Save the file to local storage (e.g., a folder on the server)
                    var filePath = Path.Combine(relativeFolderPath, fileName);
                    await System.IO.File.WriteAllBytesAsync(filePath, fileBytes);

                    return Ok("File uploaded successfully!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error uploading file: {ex.Message}");
            }
        }



        [HttpPost("uploaddesc")]
        public async Task<IActionResult> UploadFiledesc()
        {

            try
            {
                // Read the file from the request body
                using (var memoryStream = new MemoryStream())
                {
                    await Request.Body.CopyToAsync(memoryStream);
                    var fileBytes = memoryStream.ToArray();

                    // Generate a unique file name based on current date and time
                    var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                    var fileName = $"Description_{timestamp}.txt";


                    var relativeFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "SavedFiles");
                    if (!Directory.Exists(relativeFolderPath))
                    {
                        Directory.CreateDirectory(relativeFolderPath);
                    }


                    // Save the file to local storage (e.g., a folder on the server)
                    var filePath = Path.Combine(relativeFolderPath, fileName);
                    await System.IO.File.WriteAllBytesAsync(filePath, fileBytes);

                    return Ok("File uploaded successfully!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error uploading file: {ex.Message}");
            }
        }

    }
}
