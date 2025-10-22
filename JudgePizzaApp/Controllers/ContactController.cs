using JudgePizzaApp.Models.ViewModels;
using JudgePizzaApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace JudgePizzaApp.Controllers;
public class ContactController : Controller
{
    private readonly IEmailService _emailService;
    private readonly EmailSettings _emailSettings;
    public ContactController(IEmailService emailService, IOptions<EmailSettings> emailSettings)
    {
        _emailService = emailService;
        _emailSettings = emailSettings.Value;
    }

    [HttpPost]
    public async Task<IActionResult> Send(ContactFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            TempData["Error"] = "Lütfen formu doğru doldurun.";
            return View(model);
        }

        try
        {
            await _emailService.SendContactFormAsync(model, _emailSettings.RecipientEmail);

            TempData["Success"] = "Mesajınız başarıyla gönderildi!";
        }
        catch (Exception ex)
        {
            TempData["Error"] = "Mesaj gönderilirken bir hata oluştu: " + ex.Message;
        }
        return RedirectToAction("Index", "Home");
    }
}
