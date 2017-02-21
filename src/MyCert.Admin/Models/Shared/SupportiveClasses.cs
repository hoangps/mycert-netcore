using System;
using System.Collections.Generic;

namespace OpenLive.Client.Admin.Models.Shared
{
    // This file is to declare supportive classes which will be used and reused crosses the projects.

    public class UserSearchData
    {
        public int Total { get; set; }
        public IList<UserDataItem> Items { get; set; } 
    }

    public class UserDataItem
    {
        public string id { get; set; }
        public string text { get; set; }
    }
    
    public class ReferenceData
    {
        public int ReferenceType { get; set; }
        public string Reference { get; set; }
    }

    public class LabelContactData
    {
        public int Total { get; set; }
        public IList<LabelContactItem> Items { get; set; }
    }

    public class LabelContactItem
    {
        public Guid Id { get; set; }
        public int LabelContactId { get; set; }
        public string Name { get; set; }
    }
    
    public class ProductCodeRecord
    {
        public string Code { get; set; }
    }
}
