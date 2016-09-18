using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenericResponseAPI.Models
{
    public class ApiLog
    {
        /// <summary>
        /// The (database) ID for the API log entry.
        /// </summary>
        public long ApiLogEntryId { get; set; }

        /// <summary>
        /// The application that made the request.
        /// </summary>
        public string Application { get; set; }

        /// <summary>
        /// The user that made the request.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// The machine that made the request.
        /// </summary>
        public string Machine { get; set; }

        /// <summary>
        /// The IP address that made the request.
        /// </summary>
        public string RequestIpAddress { get; set; }

        /// <summary>
        /// The request URI.
        /// </summary>
        public string RequestUri { get; set; }

        /// <summary>
        /// The request method (GET, POST, etc).
        /// </summary>
        public string RequestMethod { get; set; }

        /// <summary>
        /// The request timestamp.
        /// </summary>
        public DateTime? RequestTimestamp { get; set; }

        /// <summary>
        /// The response status code.
        /// </summary>
        public int? ResponseStatusCode { get; set; }

        /// <summary>
        /// The response timestamp.
        /// </summary>
        public DateTime? ResponseTimestamp { get; set; }
    }
}