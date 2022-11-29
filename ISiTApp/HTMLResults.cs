using Microsoft.AspNetCore.Mvc;

namespace ISiTApp
{
    public class HTMLResults : IActionResult
    {
        string htmlCode;
        public HTMLResults(string html) => htmlCode = html;
        public async Task ExecuteResultAsync(ActionContext context)
        {
            string fullHtmlCode = @$"<!DOCTYPE html>
            <html>
                <head>
                    <title>METANIT.COM</title>
                    <meta charset=utf-8 />
                </head>
                <body>{htmlCode}</body>
            </html>";
            await context.HttpContext.Response.WriteAsync(fullHtmlCode);
        }
    }
}
