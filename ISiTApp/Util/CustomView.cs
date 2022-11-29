using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace ISiTApp.Util
{
    public class CustomView : IView
    {
        public CustomView(string viewPath)
        {
            Path = viewPath;
        }
        public string Path { get; set; }
        public async Task RenderAsync(ViewContext context)
        {
            string content = "";
            using (StreamReader viewReader = new StreamReader(Path))
            {
                content = await viewReader.ReadToEndAsync();
            }
            await context.Writer.WriteAsync(content);
        }
    }
}
