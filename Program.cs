namespace atividadeCBE2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Projeto web - LH pets versão 1");

        app.UseStaticfiles();
        app.MapGet("/index", (HttpContext contexto)=> {
            contexto.Response.Redirect("index.html", false);

        });

        Banco dba=new Banco();
        app.MapGet("/listaClientes", (HttpContext contexto) => {
            contexto.Response.WriteAsync(dba.GetListaString());
            
        });


        app.Run();
    }
}
