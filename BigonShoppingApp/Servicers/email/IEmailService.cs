namespace BigonShoppingApp.Servicers.email
{
    public interface IEmailService
    {

         Task<bool> SendAsync(string to,string title,string body,bool isHTML = true);
    }
}
