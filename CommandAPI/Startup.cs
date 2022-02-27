namespace CommandAPI
{
 public class Startup
 {
 public void ConfigureServices(IServiceCollection services)
 {
 //SECTION 1. Add code below
 services.AddControllers();
 }
 public void Configure(IApplicationBuilder app,
IWebHostEnvironment env)
 {
 if (env.IsDevelopment())
 {
 app.UseDeveloperExceptionPage();
 }
 app.UseRouting();
 app.UseEndpoints(endpoints =>
 {
 //SECTION 2. Add code below
 endpoints.MapControllers();
 });
 }
 }
}