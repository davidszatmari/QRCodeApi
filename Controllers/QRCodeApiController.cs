using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace QRCodeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRCodeApiController : ControllerBase
    {
        [HttpPost("generate")]
        public IActionResult Generate([FromBody] QRRequest request)
        {
            if (string.IsNullOrEmpty(request.Text))
            {
                return BadRequest("Text cannot be empty");
            }

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(request.Text, QRCodeGenerator.ECCLevel.Q);
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
                    {
                        using (var ms = new MemoryStream())
                        {
                            qrCodeImage.Save(ms, ImageFormat.Png);
                            var base64Image = Convert.ToBase64String(ms.ToArray());
                            return Ok(new { ImageBase64 = "data:image/png;base64," + base64Image });
                        }
                    }
                }
            }
        }
    }

    public class QRRequest
    {
        public string Text { get; set; }
    }
}
