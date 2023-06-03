﻿using Microsoft.AspNetCore.Mvc;
using VoteApp.Database;
using VoteApp.Database.Document;
using VoteApp.Host.Service;


namespace VoteApp.Host.Controllers.Client;

public class UploadController : AbstractClientController
{
    private readonly IDocumentService _documentService;


    public UploadController(IDatabaseContainer databaseContainer, IDocumentService documentService) : base(databaseContainer)
    {
        _documentService = documentService;
    }

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile? photo)
    {
        //ToDo: Inject User ids from cookies
        // var user = await DatabaseContainer.UserWeb.GetOneById(requestUser.Id);

        if (photo is null || photo.Length <= 0)
        {
            return BadRequest();
        }

        const int maxFileSizeInBytes = 10 * 1024 * 1024;

        if (photo.Length > maxFileSizeInBytes)
        {
            return BadRequest("Размер фото превышает 5 мегабайт.");
        }

        await _documentService.UploadDocument(1, photo, DocumentStatus.Default);

        return Ok();
    }
}