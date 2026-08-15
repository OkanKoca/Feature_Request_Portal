$(function () {
    var l = abp.localization.getResource('Feature_Request_Portal');
    var featureRequestsService = feature_Request_Portal.featureRequests.featureRequest;

    // Same mapping as FeatureRequestStatusBadge.CssClass on the server; keep both in sync.
    var statusBadgeClasses = {
        0: 'bg-secondary', // Pending
        1: 'bg-success',   // Approved
        2: 'bg-danger',    // Rejected
        3: 'bg-primary',   // Planned
        4: 'bg-info',      // Completed
        5: 'bg-dark'       // Cancelled
    };

    // Returns null when the filter is absent, which is the case for anonymous users.
    var getFilter = function () {
        return { status: $('#StatusFilter').val() || null }
    }

    var dataTable = $('#FeatureRequestsTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        serverSide: true,
        paging: true,
        pageLength: 15,
        lengthChange: false, // page size is fixed at 15
        order: [],
        searching: false,
        scrollX: true,
        ajax: abp.libs.datatables.createAjax(featureRequestsService.getList, getFilter),
        columnDefs: [
            {
                title: l('Title'),
                data: "title",
                orderable: false,
                render: function (data, type, row) {
                    var url = abp.appPath + 'FeatureRequests/Detail/' + row.id;
                    return '<a href="' + url + '">' + $('<div>').text(data).html() + '</a>';
                }
            },
            {
                title: l('VoteCount'),
                data: "voteCount",
                orderable: true,
                // Most voted first, then least voted, then back to the server default
                // ordering (newest first). The empty state is what DataTables uses to
                // clear the sort, so keep it in the cycle.
                orderSequence: ['desc', 'asc', ''],
            },
            {
                title: l('Status'),
                data: "status",
                orderable: false,
                render: function (data) {
                    var cssClass = statusBadgeClasses[data] || 'bg-secondary';
                    return '<span class="badge ' + cssClass + '">'
                        + l('Enum:FeatureRequestStatus.' + data)
                        + '</span>';
                }
            },
            {
                title: l('CreationTime'),
                data: "creationTime",
                orderable: false,
                dataFormat: "datetime"
            }
        ]
        })
    );

    $('#StatusFilter').on('change', function () {
        dataTable.ajax.reload();
    });

});