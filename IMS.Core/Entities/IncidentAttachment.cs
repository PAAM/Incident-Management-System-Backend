using IMS.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Entities
{
    public class IncidentAttachment : BaseEntity
    {
        public string IncidentNumber { get; private set; } = string.Empty;
        public string FileName { get; private set; } = string.Empty;
        public long FileSize { get; private set; }
        public int UploadedByUserId { get; private set; }

        //Navigation Property
        public User User { get; private set; } = null!;
        public Incident Incident { get; private set; } = null!;

        private IncidentAttachment() { }
        public IncidentAttachment(string incidentNumber, string fileName, long fileSize, int uploadedByUserId)
        {
            if (string.IsNullOrWhiteSpace(incidentNumber))
                throw new ArgumentNullException(nameof(incidentNumber), "incidentNumber cannot be empty.");

            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException(nameof(fileName), "fileName cannot be empty.");

            if (uploadedByUserId <= 0)
                throw new ArgumentException("uploadedByUserId must be greater than zero.", nameof(uploadedByUserId));

            if (fileSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(fileSize), "fileSize must be greater than zero.");

            IncidentNumber = incidentNumber;
            FileName = fileName;
            FileSize = fileSize;
            UploadedByUserId = uploadedByUserId;
        }

    }
}

