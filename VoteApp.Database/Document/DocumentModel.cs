﻿using System;
using System.Collections.Generic;
using VoteApp.Database.CandidateDocument;
using VoteApp.Database.User;


namespace VoteApp.Database.Document;

public class DocumentModel : AbstractModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public UserModel UserModel { get; set; }
    public string DocumentExtension { get; set; }
    public string Path { get; set; }
    public DateTime CreatedAt { get; set; }
    public DocumentStatus DocumentStatus { get; set; }
    
    public List<CandidateDocumentModel> CandidateDocuments { get; set; }

    public static DocumentModel CreateModel(
        int userId,
        string documentExtension,
        string path,
        DocumentStatus documentStatus
    )
    {
        return new DocumentModel
        {
            UserId = userId,
            DocumentExtension = documentExtension,
            CreatedAt = DateTime.UtcNow,
            Path = path,
            DocumentStatus = documentStatus,
        };
    }
}