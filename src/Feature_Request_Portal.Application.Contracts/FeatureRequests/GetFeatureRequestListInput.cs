using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Feature_Request_Portal.FeatureRequests
{
    public class GetFeatureRequestListInput : PagedAndSortedResultRequestDto
    {
        public FeatureRequestStatus? Status { get; set; }
    }
}
