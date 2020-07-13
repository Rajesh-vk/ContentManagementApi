using DataAccessLayer.InterFace;
using MongoDB.Bson;
using System;

namespace DataAccessLayer.Implementation
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}
