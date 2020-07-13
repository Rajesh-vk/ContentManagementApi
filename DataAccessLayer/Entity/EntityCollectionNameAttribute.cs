using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entity
{

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class EntityCollectionNameAttribute : Attribute
    {
        public string CollectionName { get; }

        public EntityCollectionNameAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }
    }
}
